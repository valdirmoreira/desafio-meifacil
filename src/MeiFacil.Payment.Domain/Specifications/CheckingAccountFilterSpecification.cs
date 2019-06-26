using MeiFacil.Payment.Domain.Entities;

namespace MeiFacil.Payment.Domain.Specifications
{
    public class CheckingAccountFilterSpecification : BaseSpecification<CheckingAccount>
    {
        public CheckingAccountFilterSpecification(int number)
            : base(i => (i.Number == number))
        {
        }
    }
}
