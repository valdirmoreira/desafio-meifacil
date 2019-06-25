using System;
using System.Collections.Generic;
using System.Linq;

namespace MeiFacil.Payment.Domain.Core.Notifications
{
    public class DomainNotificationHandler : IDomainNotificationHandler, IDisposable
    {
        public DomainNotificationHandler()
        {
            _notifications = new List<DomainNotification>();
        }

        private List<DomainNotification> _notifications;

        public List<DomainNotification> GetNotifications()
        {
            return _notifications;
        }

        public void Handle(DomainNotification notification)
        {
            _notifications.Add(notification);
        }

        public bool HasNotifications()
        {
            return GetNotifications().Any();
        }

        public void Dispose()
        {
            _notifications = new List<DomainNotification>();
            GC.SuppressFinalize(this);
        }
    }
}
