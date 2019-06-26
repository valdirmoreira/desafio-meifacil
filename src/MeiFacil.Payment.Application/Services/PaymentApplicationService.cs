using AutoMapper;
using MeiFacil.Payment.Application.Interfaces;
using MeiFacil.Payment.Application.ViewModels.Payment;
using MeiFacil.Payment.Domain.Interfaces;
using System.Threading.Tasks;

namespace MeiFacil.Payment.Application.Services
{
    public class PaymentApplicationService : IPaymentApplicationService
    {
        private readonly IMapper _mapper;
        private readonly IPaymentService _paymentService;

        public PaymentApplicationService(
            IMapper mapper,
            IPaymentService paymentService)
        {
            _paymentService = paymentService;
            _mapper = mapper;
        }

        public async Task<PaymentViewModel> AddAsync(CreatePaymentViewModel model)
        {
            var entity = await _paymentService.AddAsync(_mapper.Map<Domain.Entities.Payment>(model));
            return _mapper.Map<PaymentViewModel>(entity);
        }
    }
}
