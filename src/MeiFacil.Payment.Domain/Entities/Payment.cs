using MeiFacil.Payment.Domain.Core.Abstracts;

namespace MeiFacil.Payment.Domain.Entities
{
    public class Payment : BaseEntity
    {
        public decimal GrossValue { get; set; }
        public decimal NetValue { get; set; }
        public int Installments { get; set; }
        public int DebitAccountNumber { get; set; }
        public int CreditAccountNumber { get; set; }
    }
}
