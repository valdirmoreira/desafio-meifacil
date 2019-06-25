using MeiFacil.Payment.Domain.Core.Notifications;
using MeiFacil.Payment.Domain.Interfaces;
using MeiFacil.Payment.Infrastructure.Data.Contexts;
using MeiFacil.Payment.Infrastructure.Data.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;

namespace MeiFacil.Payment.Infrastructure.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Domain - Notification
            services.AddScoped<IDomainNotificationHandler, DomainNotificationHandler>();

            // Infrastructure - Data
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<PaymentContext>();
        }
    }
}
