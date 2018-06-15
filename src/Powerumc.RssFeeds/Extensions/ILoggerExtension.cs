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
        
        public static void Log(this ILogger logger, TraceId traceId, string message)
        {
            logger.LogTrace($"{traceId}|{message}");
        }
    }
}