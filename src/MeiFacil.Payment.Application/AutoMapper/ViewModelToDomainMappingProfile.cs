using AutoMapper;
using MeiFacil.Payment.Application.ViewModels.CheckingAccount;
using MeiFacil.Payment.Application.ViewModels.Entry;
using MeiFacil.Payment.Application.ViewModels.Payment;
using MeiFacil.Payment.Domain.Entities;

namespace MeiFacil.Payment.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<CheckingAccountViewModel, CheckingAccount>();
            CreateMap<EntryViewModel, Entry>();
            CreateMap<PaymentViewModel, Domain.Entities.Payment>();
            CreateMap<CreatePaymentViewModel, Domain.Entities.Payment>();
        }
    }
}
