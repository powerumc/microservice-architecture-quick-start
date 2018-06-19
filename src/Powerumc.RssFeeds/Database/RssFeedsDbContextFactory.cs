using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;

namespace Powerumc.RssFeeds.Database
{
    public class RssFeedsDbContextFactory : IRssFeedsDbContextFactory
    {
        private DbContextOptions _readDbContextOptions;
        private DbContextOptions _writeDbContextOptions;

        public RssFeedsDbContext CreateRead()
        {
            if (_readDbContextOptions != null) return new RssFeedsDbContext(_readDbContextOptions);

            var optionsBuilder = CreateOptionBuilder("rssfeeds-db");

            _readDbContextOptions = optionsBuilder.Options;

            return new RssFeedsDbContext(_readDbContextOptions);
        }

        public RssFeedsDbContext CreateWrite()
        {
            if (_writeDbContextOptions != null) return new RssFeedsDbContext(_writeDbContextOptions);

            var optionsBuilder = CreateOptionBuilder("rssfeeds-db");

            _writeDbContextOptions = optionsBuilder.Options;

            return new RssFeedsDbContext(_writeDbContextOptions);
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