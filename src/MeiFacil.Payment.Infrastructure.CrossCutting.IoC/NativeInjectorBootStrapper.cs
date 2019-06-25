using MeiFacil.Payment.Domain.Core.Notifications;
using MeiFacil.Payment.Domain.Interfaces;
using MeiFacil.Payment.Domain.Services;
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

            // Domain - Services
            services.AddScoped<ICheckingAccountService, CheckingAccountService>();
            services.AddScoped<IEntryService, EntryService>();
            services.AddScoped<IPaymentService, PaymentService>();

            // Infrastructure - Data
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<PaymentContext>();
        }
    }
}
