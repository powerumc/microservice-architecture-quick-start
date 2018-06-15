namespace Powerumc.RssFeeds.Database
{
    public interface IRssFeedsDbContextFactory
    {
        RssFeedsDbContext Create();
    }
}