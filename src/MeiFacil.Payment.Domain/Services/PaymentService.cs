using MeiFacil.Payment.Domain.Core.Notifications;
using MeiFacil.Payment.Domain.Entities;
using MeiFacil.Payment.Domain.Interfaces;
using MeiFacil.Payment.Domain.Specifications;
using System.Linq;
using System.Threading.Tasks;

namespace MeiFacil.Payment.Domain.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IUnitOfWork _unitOfWork;
        protected readonly IDomainNotificationHandler _notifications;

        public PaymentService(
            IUnitOfWork unitOfWork,
            IDomainNotificationHandler notifications)
        {
            _unitOfWork = unitOfWork;
            _notifications = notifications;
        }

        public async Task<Entities.Payment> AddAsync(Entities.Payment entity)
        {
            _unitOfWork.PaymentRepository.Add(entity);
            var commit = await _unitOfWork.CommitAsync();
            if (!commit)
                return await Task.FromResult<Entities.Payment>(null);

            return (await _unitOfWork.PaymentRepository.GetByIdAsync(entity.Id));
        }

        public async Task<Entities.Payment> CreateAsync(decimal value, int installments, int debitAccountNumber, int creditAccountNumber)
        {

            #region Validate Accounts
            var debitAccount = (await _unitOfWork
                .CheckingAccountRepository
                .ListAsync(new CheckingAccountFilterSpecification(debitAccountNumber)))
                .FirstOrDefault();

            if (debitAccount == null)
            {
                _notifications.Handle(new DomainNotification(string.Empty, "debit account not found"));
            }

            var creditAccount = (await _unitOfWork
                .CheckingAccountRepository
                .ListAsync(new CheckingAccountFilterSpecification(creditAccountNumber)))
                .FirstOrDefault();

            if (debitAccount == null)
            {
                _notifications.Handle(new DomainNotification(string.Empty, "credit account not found"));
            }
            #endregion

            #region Create Entries
            var debitEntry = new Entry
            {
                CheckingAccountNumber = debitAccount.Number,
                Type = "D",
                Value = value
            };

            var creditEntry = new Entry
            {
                CheckingAccountNumber = creditAccount.Number,
                Type = "C",
                Value = value
            };


            _unitOfWork.EntryRepository.Add(debitEntry);
            _unitOfWork.EntryRepository.Add(creditEntry);

            #endregion

            #region Create Payment
            var payment = new Domain.Entities.Payment
            {
                GrossValue = value,
                NetValue = value, // ToDO
                Installments = installments,
                CreditAccountNumber = creditAccount.Number,
                DebitAccountNumber = debitAccount.Number
            };

            _unitOfWork.PaymentRepository.Add(payment);
            #endregion

            #region Account Balance Update
            #endregion
        }
    }
}
