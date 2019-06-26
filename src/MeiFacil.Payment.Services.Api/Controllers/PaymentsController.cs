using MeiFacil.Payment.Application.Interfaces;
using MeiFacil.Payment.Application.ViewModels.Payment;
using MeiFacil.Payment.Domain.Core.Notifications;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace MeiFacil.Payment.Services.Api.Controllers
{
    public class PaymentsController : BaseController
    {
        private readonly IPaymentApplicationService _paymentApplicationService;

        public PaymentsController(
            IDomainNotificationHandler notifications,
            IPaymentApplicationService paymentApplicationService) : base(notifications)
        {
            _paymentApplicationService = paymentApplicationService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreatePaymentViewModel model)
        {
            var response = await _paymentApplicationService.AddAsync(model);
            return Response(response, (int)HttpStatusCode.Created);
        }
    }
}