using Microsoft.AspNetCore.Mvc;

namespace Powerumc.RssFeeds.Api.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/hc")]
    public class HealthChecksController : ApiController
    {
        [HttpGet]
        public IActionResult HealthCheck()
        {
            return Ok("ok");
        }
    }
}