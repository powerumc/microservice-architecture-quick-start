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

        public RssFeedsDbContext CreateRead()
        {
            if (_dbContextOptions != null) return new RssFeedsDbContext(_dbContextOptions);

            var optionsBuilder = CreateOptionBuilder("rssfeeds-db");

            _dbContextOptions = optionsBuilder.Options;

            return new RssFeedsDbContext(_dbContextOptions);
        }

        public RssFeedsDbContext CreateWrite()
        {
            if (_dbContextOptions != null) return new RssFeedsDbContext(_dbContextOptions);

            var optionsBuilder = CreateOptionBuilder("rssfeeds-db");

            _dbContextOptions = optionsBuilder.Options;

            return new RssFeedsDbContext(_dbContextOptions);
        }
        
        private static DbContextOptionsBuilder CreateOptionBuilder(string dbName)
        {
            var optionsBuilder = new DbContextOptionsBuilder();
            optionsBuilder
                .UseLoggerFactory(new LoggerFactory(new[]
                {
                    new ConsoleLoggerProvider((message, level) => true, true)
                }))
                .UseInMemoryDatabase(dbName)
                .EnableSensitiveDataLogging();

            return optionsBuilder;
        }
    }
}