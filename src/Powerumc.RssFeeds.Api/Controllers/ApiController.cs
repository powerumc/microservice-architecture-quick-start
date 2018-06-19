using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Powerumc.RssFeeds.Domain.Responses;

namespace Powerumc.RssFeeds.Api.Controllers
{
    public class ApiController : ControllerBase
    {
        [NonAction]
        public IActionResult Error(TraceId traceId)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse(traceId));
        }
    }
}