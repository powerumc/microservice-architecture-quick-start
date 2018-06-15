using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Powerumc.RssFeeds.Extensions;

namespace Powerumc.RssFeeds.Api.Controllers.V1
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/rssfeeds")]
    public class RssFeedsController : ApiController
    {
        private readonly TraceId _traceId;
        private readonly ILogger<RssFeedsController> _logger;

        public RssFeedsController(TraceId traceId,
                                  ILogger<RssFeedsController> logger)
        {
            _traceId = traceId;
            _logger = logger;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Domain.Responses.V1.RssFeedResponse), 200)]
        [ProducesResponseType(typeof(Domain.Responses.ErrorResponse), 500)]
        public IActionResult Get([FromRoute] Domain.Requests.V1.RssFeedGetByIdRequest request)
        {
            try
            {
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogError(_traceId, e);
                return Error(_traceId);
            }
        }
    }
}