using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Powerumc.RssFeeds.Domain;
using Powerumc.RssFeeds.Domain.Responses.V1;

namespace Powerumc.RssFeeds.Services
{
    [Register(typeof(IRssFeedsHttpService))]
    public class RssFeedsHttpService : IRssFeedsHttpService
    {
        private readonly IRssFeedsService _rssFeedsService;
        private readonly IHttpClientFactory _httpClientFactory;

        public RssFeedsHttpService(IRssFeedsService rssFeedsService,
            IHttpClientFactory httpClientFactory)
        {
            _rssFeedsService = rssFeedsService;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<Domain.Responses.V1.RssFeedItemResponse> AllItemsAsync()
        {
            var result = new Domain.Responses.V1.RssFeedItemResponse {Items = new List<Item>()};
            var feeds = await _rssFeedsService.ListAsync(null, new PagingInfo {PageNo = 1, PageSize = int.MaxValue});

            foreach (var feed in feeds.Results)
            {
                using (var httpClient = _httpClientFactory.CreateClient())
                {
                    var feedUri = new Uri(feed.Url);
                    httpClient.BaseAddress = new Uri(feedUri.AbsoluteUri);

                    var responseContent = await httpClient.GetAsync("/rss");
                    var responseStream = await responseContent.Content.ReadAsStreamAsync();

                    var xmlSerializer = new XmlSerializer(typeof(Domain.Responses.V1.Rss));

                    if (xmlSerializer.Deserialize(responseStream) is Rss rss) 
                        result.Items.AddRange(rss.Channel.Item);
                }
            }

            return await Task.FromResult(result);
        }
    }
}