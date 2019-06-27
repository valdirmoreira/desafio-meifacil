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
            #region Verifica se as contas existem
            var debitAccount = (await _unitOfWork
                .CheckingAccountRepository
                .ListAsync(new CheckingAccountFilterSpecification(debitAccountNumber)))
                .FirstOrDefault();

            if (debitAccount == null)
                _notifications.Handle(new DomainNotification(string.Empty, "Debit Account not found"));

            var creditAccount = (await _unitOfWork
                .CheckingAccountRepository
                .ListAsync(new CheckingAccountFilterSpecification(creditAccountNumber)))
                .FirstOrDefault();

            if (debitAccount == null)
                _notifications.Handle(new DomainNotification(string.Empty, "Credit Account not found"));

            if (_notifications.HasNotifications())
                return await Task.FromResult<Entities.Payment>(null);
            #endregion

            #region Calculas as taxas
            var netValue = CalculateTax(value, installments);
            #endregion

            #region Verifica o saldo da conta de débito
            if (debitAccount.Balance < netValue)
                _notifications.Handle(new DomainNotification(string.Empty, "The debit account is not enough"));
            #endregion

            #region Insere os lançamentos
            var debitEntry = new Entry
            {
                CheckingAccountNumber = debitAccount.Number,
                Type = "D",
                Value = netValue
            };

            var creditEntry = new Entry
            {
                CheckingAccountNumber = creditAccount.Number,
                Type = "C",
                Value = netValue
            };
            #endregion

            #region Criação do pagamento
            var payment = new Domain.Entities.Payment
            {
                GrossValue = value,
                NetValue = netValue,
                Installments = installments,
                CreditAccountNumber = creditAccount.Number,
                DebitAccountNumber = debitAccount.Number
            };
            #endregion

            #region Atualiza o saldo das contas
            debitAccount.Balance -= netValue;
            creditAccount.Balance += netValue;
            #endregion

            #region Commit
            _unitOfWork.EntryRepository.Add(debitEntry);
            _unitOfWork.EntryRepository.Add(creditEntry);
            _unitOfWork.PaymentRepository.Add(payment);
            _unitOfWork.CheckingAccountRepository.Update(debitAccount);
            _unitOfWork.CheckingAccountRepository.Update(creditAccount);

            if (!(await _unitOfWork.CommitAsync()))
                return await Task.FromResult<Entities.Payment>(null);
            #endregion

            return payment;
        }

        public decimal CalculateTax(decimal value, int installments)
        {
            if (installments == 0 || value == 0)
                return 0;

            decimal tax;

            switch (installments)
            {
                case 1:
                    tax = 3.79M;
                    break;
                case 2:
                    tax = 5.78M;
                    break;
                case 3:
                    tax = 7.77M;
                    break;
                default:
                    tax = 7.77M;
                    break;
            }

            return value + ((value * tax) / 100);
        }
    }
}
