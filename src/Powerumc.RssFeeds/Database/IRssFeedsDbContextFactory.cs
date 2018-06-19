namespace Powerumc.RssFeeds.Database
{
    public interface IRssFeedsDbContextFactory
    {
        RssFeedsDbContext CreateRead();
        RssFeedsDbContext CreateWrite();
    }
}