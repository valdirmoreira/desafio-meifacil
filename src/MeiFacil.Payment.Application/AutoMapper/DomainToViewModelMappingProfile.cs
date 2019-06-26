using AutoMapper;
using MeiFacil.Payment.Application.ViewModels.CheckingAccount;
using MeiFacil.Payment.Application.ViewModels.Entry;
using MeiFacil.Payment.Application.ViewModels.Payment;
using MeiFacil.Payment.Domain.Entities;

namespace MeiFacil.Payment.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<CheckingAccount, CheckingAccountViewModel>();
            CreateMap<Entry, EntryViewModel>();
            CreateMap<Domain.Entities.Payment, PaymentViewModel>();
            CreateMap<Domain.Entities.Payment, CreatePaymentViewModel>();
        }
    }
}
