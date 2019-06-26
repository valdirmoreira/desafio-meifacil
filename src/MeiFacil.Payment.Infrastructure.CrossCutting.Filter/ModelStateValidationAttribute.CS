using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;

namespace MeiFacil.Payment.Infrastructure.CrossCutting.Filter
{
    public class ModelStateValidationAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var errors = (from modelState in context.ModelState.Values
                              from error in modelState.Errors
                              select error.ErrorMessage)
                              .ToList();

                context.Result = new BadRequestObjectResult(new
                {
                    success = false,
                    errors
                });
            }
        }
    }
}
