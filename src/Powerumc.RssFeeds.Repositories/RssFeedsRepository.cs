using Microsoft.Extensions.Logging;
using Powerumc.RssFeeds.Database;
using Powerumc.RssFeeds.Database.Models;

namespace Powerumc.RssFeeds.Repositories
{
    [Register(typeof(IRssFeedsRepository))]
    public class RssFeedsRepository : Repository<Database.Models.RssFeed>, IRssFeedsRepository
    {
        public RssFeedsRepository(ILogger<Repository<RssFeed>> logger,
            IRssFeedsDbContextFactory dbContextFactory) : base(logger, dbContextFactory)
        {
        }
    }
}