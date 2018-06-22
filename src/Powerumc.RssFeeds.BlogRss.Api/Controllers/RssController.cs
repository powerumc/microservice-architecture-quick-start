using System.IO;
using System.Xml.Serialization;
using Microsoft.AspNetCore.Mvc;

namespace Powerumc.RssFeeds.BlogRss.Api.Controllers
{
    [Route("/rss")]
    [ApiController]
    public class RssController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            return File(System.IO.File.Open("rss.xml", FileMode.Open), "application/xml");
        }
    }
}