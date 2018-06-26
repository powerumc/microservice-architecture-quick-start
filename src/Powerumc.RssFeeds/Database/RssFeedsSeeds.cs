using System;
using System.Linq;
using System.Threading.Tasks;

namespace Powerumc.RssFeeds.Database
{
    public static class RssFeedsSeeds
    {
        public static void Seed(this IRssFeedsDbContextFactory dbContextFactory)
        {
            using (var dbContext = dbContextFactory.CreateWrite())
            {
                dbContext.Database.EnsureCreated();

                if (dbContext.RssFeeds.Any()) return;
                
                var rssFeed1 = new Database.Models.RssFeed
                {
                    Title = "Powerumc Blog",
                    Url = "http://blog/rss",
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                };

                dbContext.RssFeeds.Add(rssFeed1);
                dbContext.SaveChanges();
            }
        }
    }
}