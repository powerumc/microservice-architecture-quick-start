using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Powerumc.RssFeeds.Api.Infrastructure.Extensions
{
    public class TraceIdMiddleware
    {
        private readonly RequestDelegate _next;

        public TraceIdMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            context.Items["TRACE_ID"] = TraceId.New();
            
            await _next(context);
        }
    }
}