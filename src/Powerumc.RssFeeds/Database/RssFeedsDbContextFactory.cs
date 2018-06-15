using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;

namespace Powerumc.RssFeeds.Database
{
    public class RssFeedsDbContextFactory : IRssFeedsDbContextFactory
    {
        private DbContextOptions _dbContextOptions;

        public RssFeedsDbContext Create()
        {
            if (_dbContextOptions != null) return new RssFeedsDbContext(_dbContextOptions);
            
            var optionsBuilder = new DbContextOptionsBuilder();
            optionsBuilder
                .UseLoggerFactory(new LoggerFactory(new[]
                {
                    new ConsoleLoggerProvider((message, level) => true, true)
                }))
                .UseInMemoryDatabase("rssfeeds-db")
                .EnableSensitiveDataLogging();

            _dbContextOptions = optionsBuilder.Options;

            return new RssFeedsDbContext(_dbContextOptions);
        }
    }
}