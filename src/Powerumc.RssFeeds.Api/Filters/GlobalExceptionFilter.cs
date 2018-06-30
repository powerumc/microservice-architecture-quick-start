using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using Powerumc.RssFeeds.Domain.Responses;

namespace Powerumc.RssFeeds.Api.Filters
{
    public class GlobalExceptionFilter : ExceptionFilterAttribute
    {
        private readonly TraceId _traceId;
        private readonly ILoggerFactory _loggerFactory;

        public GlobalExceptionFilter(TraceId traceId,
            ILoggerFactory loggerFactory)
        {
            _traceId = traceId;
            _loggerFactory = loggerFactory;
        }

        public override void OnException(ExceptionContext context)
        {
            context.Result = new ObjectResult(new ErrorResponse(_traceId))
            {
                StatusCode = StatusCodes.Status500InternalServerError
            };
        }

        public override Task OnExceptionAsync(ExceptionContext context)
        {
            context.Result = new ObjectResult(new ErrorResponse(_traceId))
            {
                StatusCode = StatusCodes.Status500InternalServerError
            };

            return Task.CompletedTask;
        }
    }
}