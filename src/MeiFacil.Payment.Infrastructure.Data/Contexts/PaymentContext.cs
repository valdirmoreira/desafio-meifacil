using MeiFacil.Payment.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MeiFacil.Payment.Infrastructure.Data.Contexts
{
    public class PaymentContext : DbContext
    {
        public PaymentContext(DbContextOptions<PaymentContext> options)
            : base(options)
        {
        }

        public DbSet<CheckingAccount> CheckingAccounts { get; set; }
        public DbSet<Entry> Entries { get; set; }
        public DbSet<Domain.Entities.Payment> Payments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
