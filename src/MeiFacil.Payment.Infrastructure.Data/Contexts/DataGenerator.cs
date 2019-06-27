using MeiFacil.Payment.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace MeiFacil.Payment.Infrastructure.Data.Contexts
{
    public class DataGenerator
    {

        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new PaymentContext(
                serviceProvider.GetRequiredService<DbContextOptions<PaymentContext>>()))
            {


                if (context.CheckingAccounts.Any())
                {
                    return;
                }

                context.CheckingAccounts.AddRange(
                    new CheckingAccount
                    {
                        Id = Guid.NewGuid(),
                        Balance = 575M,
                        Number = 1993
                    },
                    new CheckingAccount
                    {
                        Id = Guid.NewGuid(),
                        Balance = 1000M,
                        Number = 2019
                    },
                    new CheckingAccount
                    {
                        Id = Guid.NewGuid(),
                        Balance = 250M,
                        Number = 2008
                    }); ;

                context.SaveChanges();
            }
        }
    }
}
