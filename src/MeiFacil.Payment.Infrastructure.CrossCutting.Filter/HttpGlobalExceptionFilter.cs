using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System.Net;

namespace MeiFacil.Payment.Infrastructure.CrossCutting.Filter
{
    public class HttpGlobalExceptionFilter : IExceptionFilter
    {
        private readonly IHostingEnvironment _env;
        private readonly ILogger<HttpGlobalExceptionFilter> _logger;

        public HttpGlobalExceptionFilter(IHostingEnvironment env, ILogger<HttpGlobalExceptionFilter> logger)
        {
            _env = env;
            _logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            _logger.LogError(new EventId(context.Exception.HResult),
                context.Exception,
                context.Exception.Message);

            var json = new JsonErrorResponse
            {
                Errors = new[] { "An error occur.Try it again." }
            };

            if (_env.IsDevelopment())
                json.DeveloperMessage = new
                {
                    error = context.Exception.Message,
                    stack = context.Exception.StackTrace,
                    innerException = context.Exception.InnerException
                };

            context.Result = new ObjectResult(json);
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.ExceptionHandled = true;
        }

        private class JsonErrorResponse
        {
            public string[] Errors { get; set; }

            public object DeveloperMessage { get; set; }
        }
    }
}
