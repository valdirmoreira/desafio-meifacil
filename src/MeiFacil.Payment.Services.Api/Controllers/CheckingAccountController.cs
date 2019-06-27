using MeiFacil.Payment.Application.Interfaces;
using MeiFacil.Payment.Application.ViewModels.CheckingAccount;
using MeiFacil.Payment.Domain.Core.Notifications;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MeiFacil.Payment.Services.Api.Controllers
{
    public class CheckingAccountController : BaseController
    {
        private readonly ICheckingAccountApplicationService _checkingAccountApplicationService;

        public CheckingAccountController(
            IDomainNotificationHandler notifications,
            ICheckingAccountApplicationService checkingAccountApplicationService) : base(notifications)
        {
            _checkingAccountApplicationService = checkingAccountApplicationService;
        }

        /// <summary>
        /// Creates a new payment
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /api/payments

        ///
        /// </remarks>
        /// <param name="numberFilterApplied>
        /// /// <param name="page>
        /// <returns>A newly created Payment</returns>
        /// <response code="201">Returns the newly created payment</response>
        /// <response code="500">If the payment is null</response>  
        [HttpGet]
        [ProducesResponseType(typeof(CheckingAccountIndexViewModel), 201)]
        public async Task<IActionResult> ListAllAsync(int? numberFilterApplied, int? page)
        {
            var itemsPage = 10;
            var response = await _checkingAccountApplicationService.GetAllAsync(page ?? 0, itemsPage, numberFilterApplied);
            return Response(response);
        }
    }
}