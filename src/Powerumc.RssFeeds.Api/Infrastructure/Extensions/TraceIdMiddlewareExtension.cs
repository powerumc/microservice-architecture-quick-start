using Microsoft.AspNetCore.Builder;

namespace Powerumc.RssFeeds.Api.Infrastructure.Extensions
{
    public static class TraceIdMiddlewareExtension
    {
        public static IApplicationBuilder UseTraceId(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<TraceIdMiddleware>();
        }
    }
}