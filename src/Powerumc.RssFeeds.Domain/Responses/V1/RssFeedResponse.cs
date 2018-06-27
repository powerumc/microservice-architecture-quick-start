using System;

namespace Powerumc.RssFeeds.Domain.Responses.V1
{
    public class RssFeedResponse
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}