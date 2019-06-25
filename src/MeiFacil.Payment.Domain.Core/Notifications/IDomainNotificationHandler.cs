using System.Collections.Generic;

namespace MeiFacil.Payment.Domain.Core.Notifications
{
    public interface IDomainNotificationHandler
    {
        void Handle(DomainNotification notification);
        List<DomainNotification> GetNotifications();
        bool HasNotifications();
        void Dispose();
    }
}
