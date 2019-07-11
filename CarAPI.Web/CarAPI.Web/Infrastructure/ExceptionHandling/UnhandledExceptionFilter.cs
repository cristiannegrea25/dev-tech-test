using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace CarAPI.Web.Infrastructure.ExceptionHandling
{
    internal class UnhandledExceptionFilter : ExceptionFilterAttribute
    {
        private readonly ILogger<UnhandledExceptionFilter> _logger;

        public UnhandledExceptionFilter(ILogger<UnhandledExceptionFilter> logger)
        {
            _logger = logger;
        }

        public override void OnException(ExceptionContext context)
        {
            var exceptionStackTrace = context.Exception.StackTrace;
            var exceptionMessage = context.Exception.Message;
            var logMessage = $"Exception Message: {exceptionMessage} \nStackTrace: {exceptionStackTrace}";

            _logger.LogError(logMessage);
        }
    }
}
