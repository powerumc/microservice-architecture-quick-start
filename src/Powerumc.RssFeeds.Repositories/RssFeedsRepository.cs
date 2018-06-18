using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Powerumc.RssFeeds.Database;
using Powerumc.RssFeeds.Database.Models;
using Powerumc.RssFeeds.Repositories;

namespace Powerumc.RssFeeds.Domain
{
    [Register(typeof(IRssFeedsRepository))]
    public class RssFeedsRepository : Repository<Database.Models.RssFeed>
    {
        public RssFeedsRepository(ILogger<Repository<RssFeed>> logger,
            IRssFeedsDbContextFactory dbContextFactory) : base(logger, dbContextFactory)
        {
        }
    }
}