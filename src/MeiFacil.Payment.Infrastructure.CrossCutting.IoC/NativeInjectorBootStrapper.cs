using FluentValidation;
using MeiFacil.Payment.Application.Interfaces;
using MeiFacil.Payment.Application.Services;
using MeiFacil.Payment.Application.Validators.CheckingAccount;
using MeiFacil.Payment.Application.Validators.Entry;
using MeiFacil.Payment.Application.Validators.Payment;
using MeiFacil.Payment.Application.ViewModels.CheckingAccount;
using MeiFacil.Payment.Application.ViewModels.Entry;
using MeiFacil.Payment.Application.ViewModels.Payment;
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

            // Application - Service
            services.AddScoped<ICheckingAccountApplicationService, CheckingAccountApplicationService>();
            services.AddScoped<IEntryApplicationService, EntryApplicationService>();
            services.AddScoped<IPaymentApplicationService, PaymentApplicationService>();

            // Application - Validators
            services.AddTransient<IValidator<CheckingAccountViewModel>, CheckingAccountViewModelValidator>();
            services.AddTransient<IValidator<EntryViewModel>, EntryViewModelValidator>();
            services.AddTransient<IValidator<PaymentViewModel>, PaymentViewModelValidator>();
        }
    }
}
