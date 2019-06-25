using MeiFacil.Payment.Domain.Entities;
using MeiFacil.Payment.Domain.Repositories;
using MeiFacil.Payment.Infrastructure.Data.Contexts;

namespace MeiFacil.Payment.Infrastructure.Data.Repositories
{
    public class EntryRepository : BaseRepository<Entry>, IEntryRepository
    {
        public EntryRepository(PaymentContext context) : base(context)
        {
        }
    }
}
