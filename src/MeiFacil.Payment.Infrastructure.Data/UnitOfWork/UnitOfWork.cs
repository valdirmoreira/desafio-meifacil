using MeiFacil.Payment.Domain.Core.Notifications;
using MeiFacil.Payment.Domain.Interfaces;
using MeiFacil.Payment.Domain.Repositories;
using MeiFacil.Payment.Infrastructure.Data.Contexts;
using MeiFacil.Payment.Infrastructure.Data.Repositories;
using System.Threading.Tasks;

namespace MeiFacil.Payment.Infrastructure.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PaymentContext _context;
        private readonly IDomainNotificationHandler _notification;
        private ICheckingAccountRepository _checkingAccountRepository;
        private IEntryRepository _entryRepository;
        private IPaymentRepository _paymentRepository;


        public UnitOfWork(PaymentContext context, IDomainNotificationHandler notification)
        {
            _context = context;
            _notification = notification;
        }

        public ICheckingAccountRepository CheckingAccountRepository
        {
            get
            {
                return _checkingAccountRepository = _checkingAccountRepository ?? new CheckingAccountRepository(_context);
            }
        }

        public IEntryRepository EntryRepository
        {
            get
            {
                return _entryRepository = _entryRepository ?? new EntryRepository(_context);
            }
        }

        public IPaymentRepository PaymentRepository
        {
            get
            {
                return _paymentRepository = _paymentRepository ?? new PaymentRepository(_context);
            }
        }

        public async Task<bool> CommitAsync()
        {
            var result = (await _context.SaveChangesAsync()) > 0;

            if (!result)
                _notification.Handle(new DomainNotification(string.Empty, "an error occurred"));

            return result;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
