using Microsoft.EntityFrameworkCore;
using Powerumc.RssFeeds.Database.Models;

namespace Powerumc.RssFeeds.Database
{
    public class RssFeedsDbContext : DbContext
    {
        public RssFeedsDbContext(DbContextOptions options) : base(options) { }
        
        public DbSet<RssFeed> RssFeeds { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<RssFeed>()
                .HasQueryFilter(o => !o.IsDeleted)
                .HasIndex(o => new {o.Url, o.IsDeleted});

            modelBuilder.Entity<RssFeedItem>()
                .HasQueryFilter(o => !o.IsDeleted)
                .HasIndex(o => new {o.Url, o.IsDeleted});
        }
    }
}