using MeiFacil.Payment.Application.Interfaces;
using MeiFacil.Payment.Application.ViewModels.Payment;
using MeiFacil.Payment.Domain.Core.Notifications;
using Microsoft.AspNetCore.Mvc;
using System;
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

        /// <summary>
        /// Creates a new payment
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /api/payments
        ///     {
        //          "value": 250,
        //          "Installments": 2,
        //          "DebitAccountNumber": 1993,
        //          "CreditAccountNumber": 2008
        ///     }
        ///
        /// </remarks>
        /// <param name="itemmodelparam>
        /// <returns>A newly created Payment</returns>
        /// <response code="201">Returns the newly created payment</response>
        /// <response code="500">If the payment is null</response>    
        [HttpPost]
        [ProducesResponseType(typeof(CreatedPaymentViewModel), 201)]
        public async Task<IActionResult> CreateAsync([FromBody] CreatePaymentViewModel model)
        {
            var response = await _paymentApplicationService.AddAsync(model);
            return Response(response, (int)HttpStatusCode.Created);
        }
    }
}