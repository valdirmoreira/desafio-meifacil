using MeiFacil.Payment.Domain.Core.Abstracts;

namespace MeiFacil.Payment.Domain.Entities
{
    public class CheckingAccount : BaseEntity
    {
        public int Number { get; set; }
        public decimal Balance { get; set; }
    }
}
