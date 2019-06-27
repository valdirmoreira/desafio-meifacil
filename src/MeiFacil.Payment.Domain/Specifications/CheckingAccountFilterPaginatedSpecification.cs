using MeiFacil.Payment.Domain.Entities;

namespace MeiFacil.Payment.Domain.Specifications
{
    public class CheckingAccountFilterPaginatedSpecification : BaseSpecification<CheckingAccount>
    {
        public CheckingAccountFilterPaginatedSpecification(int skip, int take, int? number)
            : base(i => (!number.HasValue || i.Number == number))
        {
            ApplyPaging(skip, take);
        }
    }
}
