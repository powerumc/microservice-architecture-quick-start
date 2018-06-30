using System;
using System.ComponentModel;

namespace Powerumc.RssFeeds.Domain.Responses
{
    public class ErrorResponse
    {
        public string TraceId { get; }
        public int Code { get; set; }
        public string Message { get; set; }
        
        public ErrorResponse(TraceId traceId)
        {
            this.TraceId = traceId.ToString();
        }
    }
}