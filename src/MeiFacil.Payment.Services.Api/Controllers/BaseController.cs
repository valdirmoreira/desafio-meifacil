using MeiFacil.Payment.Domain.Core.Notifications;
using MeiFacil.Payment.Infrastructure.CrossCutting.Filter;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace MeiFacil.Payment.Services.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [ModelStateValidation]
    public abstract class BaseController : Controller
    {
        protected BaseController(IDomainNotificationHandler notifications)
        {
            _notifications = notifications;
        }

        protected readonly IDomainNotificationHandler _notifications;
        protected IEnumerable<DomainNotification> Notifications => _notifications.GetNotifications();

        protected bool IsValidOperation()
        {
            return !_notifications.HasNotifications();
        }

        protected IActionResult Error(string message = null, HttpStatusCode statusCode = HttpStatusCode.InternalServerError)
        {
            if (IsValidOperation())
            {
                if (message == null)
                {
                    return new ObjectResult(null)
                    {
                        StatusCode = (int)statusCode
                    };
                }
                else
                {
                    return new ObjectResult(new
                    {
                        errors = message
                    })
                    {
                        StatusCode = (int)statusCode
                    };
                }
            }
            else
            {
                var result = new ObjectResult(new
                {
                    errors = _notifications.GetNotifications().Select(n => n.Value)
                })
                {
                    StatusCode = (int)HttpStatusCode.InternalServerError
                };

                return result;
            }
        }

        protected new IActionResult Response(object data = null, int statusCode = 200)
        {
            if (IsValidOperation())
            {
                var result = new ObjectResult(new
                {
                    data
                })
                {
                    StatusCode = statusCode
                };

                return result;
            }
            else
            {
                var result = new ObjectResult(new
                {
                    errors = _notifications.GetNotifications().Select(n => n.Value)
                })
                {
                    StatusCode = (int)HttpStatusCode.InternalServerError
                };

                return result;
            }
        }

        protected void NotifyModelStateErrors()
        {
            var erros = ModelState.Values.SelectMany(v => v.Errors);
            foreach (var erro in erros)
            {
                var erroMsg = erro.Exception == null ? erro.ErrorMessage : erro.Exception.Message;
                NotifyError(string.Empty, erroMsg);
            }
        }

        protected void NotifyError(string code, string message)
        {
            _notifications.Handle(new DomainNotification(code, message));
        }
    }
}