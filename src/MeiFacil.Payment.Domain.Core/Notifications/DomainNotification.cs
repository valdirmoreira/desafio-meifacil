using System;

namespace MeiFacil.Payment.Domain.Core.Notifications
{
    public class DomainNotification
    {
        public Guid Id { get; private set; }
        public string Key { get; private set; }
        public string Value { get; private set; }
        public int Version { get; private set; }
        public DateTime Timestamp { get; set; }

        public DomainNotification(string key, string value)
        {
            Id = Guid.NewGuid();
            Version = 1;
            Key = key;
            Value = value;
            Timestamp = DateTime.Now;
        }
    }
}
