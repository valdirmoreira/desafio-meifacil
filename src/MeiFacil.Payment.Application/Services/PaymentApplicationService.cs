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
        private readonly ICheckingAccountService _checkingAccountService;

        public PaymentApplicationService(
            IMapper mapper,
            IPaymentService paymentService,
            ICheckingAccountService checkingAccountService)
        {
            _paymentService = paymentService;
            _mapper = mapper;
            _checkingAccountService = checkingAccountService;
        }

        public async Task<CreatedPaymentViewModel> AddAsync(CreatePaymentViewModel model)
        {
            var entity = await _paymentService.CreateAsync(model.Value, model.Installments, model.DebitAccountNumber, model.CreditAccountNumber);

            if (entity != null)
            {
               var debitAccount = await _checkingAccountService.GetByNumberAsync(entity.DebitAccountNumber);
               var creditAccount = await _checkingAccountService.GetByNumberAsync(entity.CreditAccountNumber);

                return new CreatedPaymentViewModel
                {
                    CreditAccountBalance = creditAccount.Balance,
                    DebitAccountBalance = debitAccount.Balance,
                    NetValue = entity.NetValue
                };
            }

            return await Task.FromResult<CreatedPaymentViewModel>(null);
        }
    }
}
