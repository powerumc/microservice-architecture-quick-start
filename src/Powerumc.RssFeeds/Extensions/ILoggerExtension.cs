using System;
using Microsoft.Extensions.Logging;

namespace Powerumc.RssFeeds.Extensions
{
    public static class ILoggerExtension
    {
        public static void LogError(this ILogger logger, TraceId traceId, Exception exception)
        {
            logger.LogError($"{traceId}|{exception}");
        }
    }
}