using System.Collections.Generic;

namespace Powerumc.RssFeeds.Domain.Responses.V1
{
    public class RssFeedItemResponse
    {
        public List<Domain.Responses.V1.Item> Items { get; set; }
    }
}