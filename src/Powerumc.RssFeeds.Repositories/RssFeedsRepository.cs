using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Powerumc.RssFeeds.Database;
using Powerumc.RssFeeds.Database.Models;
using Powerumc.RssFeeds.Repositories;

namespace Powerumc.RssFeeds.Domain
{
    [Register(typeof(IRssFeedsRepository))]
    public class RssFeedsRepository : IRssFeedsRepository
    {
        private readonly IRssFeedsDbContextFactory _dbContextFactory;

        public RssFeedsRepository(IRssFeedsDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public Task<RssFeed> GetAsync(long id)
        {
            using (var dbContext = _dbContextFactory.Create())
            {
                var query = from feed in dbContext.RssFeeds
                            where feed.Id == id
                            select feed;

                return query.SingleOrDefaultAsync();
            }
        }

        public Task<PagingResult<IEnumerable<RssFeed>>> List(Expression<Func<RssFeed, bool>> expression, PagingInfo pagingInfo)
        {
            using (var dbContext = _dbContextFactory.Create())
            {
                var query = from feed in dbContext.RssFeeds
                            select feed;

                if (expression != null)
                {
                    query = query.Where(expression);
                }

                var pagingQuery = query.Skip((pagingInfo.PageNo - 1) * pagingInfo.PageSize)
                    .Take(pagingInfo.PageSize);

                return Task.FromResult(new PagingResult<IEnumerable<RssFeed>>
                {
                    TotalCount = query.Count(),
                    Results = pagingQuery.ToList()
                });
            }
        }

        public async Task<RssFeed> CreateAsync(RssFeed model)
        {
            using (var dbContext = _dbContextFactory.Create())
            {
                var entity = dbContext.RssFeeds.Add(model);
                await dbContext.SaveChangesAsync();

                return await Task.FromResult(entity.Entity);
            }
        }

        public async Task<RssFeed> UpdateAsync(RssFeed model)
        {
            using (var dbContext = _dbContextFactory.Create())
            {
                var entity = dbContext.RssFeeds.Update(model);
                await dbContext.SaveChangesAsync();
                
                return await Task.FromResult(entity.Entity);
            }
        }

        public async Task RemoveAsync(RssFeed model)
        {
            using (var dbContext = _dbContextFactory.Create())
            {
                dbContext.RssFeeds.Remove(model);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}