using MeiFacil.Payment.Domain.Entities;
using MeiFacil.Payment.Domain.Repositories;
using MeiFacil.Payment.Infrastructure.Data.Contexts;

namespace MeiFacil.Payment.Infrastructure.Data.Repositories
{
    public class CheckingAccountRepository : BaseRepository<CheckingAccount>, ICheckingAccountRepository
    {
        public CheckingAccountRepository(PaymentContext context) : base(context)
        {
        }
    }
}
