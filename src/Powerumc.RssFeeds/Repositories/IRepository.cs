using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Powerumc.RssFeeds.Domain;

namespace Powerumc.RssFeeds.Repositories
{
    public interface IRepository<TDatabaseModel>
    {
        Task<TDatabaseModel> GetAsync(long id,
            Func<IQueryable<TDatabaseModel>, IQueryable<TDatabaseModel>> additionQuery = null);

        Task<PagingResult<IEnumerable<TDatabaseModel>>> List(Expression<Func<TDatabaseModel, bool>> expression,
            PagingInfo pagingInfo,
            Func<IQueryable<TDatabaseModel>, IQueryable<TDatabaseModel>> additionQuery = null);

        Task<TDatabaseModel> CreateAsync(TDatabaseModel model);

        Task<TDatabaseModel> UpdateAsync(TDatabaseModel model);
        
        Task RemoveAsync(TDatabaseModel model);
    }
}