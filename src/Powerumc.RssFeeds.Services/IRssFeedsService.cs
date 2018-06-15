using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Powerumc.RssFeeds.Database.Models;
using Powerumc.RssFeeds.Domain;
using Powerumc.RssFeeds.Domain.Models;
using Powerumc.RssFeeds.Domain.Requests.V1;

namespace Powerumc.RssFeeds.Services
{
    public interface IRssFeedsService
    {
        Task<PagingResult<IEnumerable<Domain.Responses.V1.RssFeedResponse>>> ListAsync(
            Expression<Func<Database.Models.RssFeed, bool>> expression, PagingInfo pagingInfo);

        Task<Domain.Responses.V1.RssFeedResponse> CreateAsync(RssFeedCreateRequest request);
    }
}