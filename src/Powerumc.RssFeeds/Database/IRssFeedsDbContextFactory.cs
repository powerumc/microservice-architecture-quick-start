using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Powerumc.RssFeeds.Database
{
    public interface IRssFeedsDbContextFactory
    {
        RssFeedsDbContext CreateRead();
        RssFeedsDbContext CreateWrite();
    }
}