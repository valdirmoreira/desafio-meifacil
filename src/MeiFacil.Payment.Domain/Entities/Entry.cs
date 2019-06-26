using MeiFacil.Payment.Domain.Core.Abstracts;

namespace MeiFacil.Payment.Domain.Entities
{
    public class Entry : BaseEntity
    {
        public string Type { get; set; }
        public int CheckingAccountNumber { get; set; }
        public decimal Value { get; set; }
    }
}
