using MeiFacil.Payment.Domain.Core.Notifications;
using MeiFacil.Payment.Domain.Interfaces;
using MeiFacil.Payment.Infrastructure.Data.Contexts;
using System.Threading.Tasks;

namespace MeiFacil.Payment.Infrastructure.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PaymentContext _context;
        private readonly IDomainNotificationHandler _notification;


        public UnitOfWork(PaymentContext context, IDomainNotificationHandler notification)
        {
            _context = context;
            _notification = notification;
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
