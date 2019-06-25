using MeiFacil.Payment.Domain.Repositories;
using MeiFacil.Payment.Infrastructure.Data.Contexts;

namespace MeiFacil.Payment.Infrastructure.Data.Repositories
{
    public class PaymentRepository : BaseRepository<Domain.Entities.Payment>, IPaymentRepository
    {
        public PaymentRepository(PaymentContext context) : base(context)
        {
        }
    }
}
