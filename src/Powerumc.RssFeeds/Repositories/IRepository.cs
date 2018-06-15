using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Powerumc.RssFeeds.Domain;

namespace Powerumc.RssFeeds.Repositories
{
    public interface IRepository<TDatabaseModel, in TKey>
    {
        TDatabaseModel Get(TKey id);

        PagingResult<IEnumerable<TDatabaseModel>> GetAll(Expression<Predicate<TDatabaseModel>> expression,
            PagingInfo pagingInfo = null);

        void Create(TDatabaseModel model);

        void Update(TDatabaseModel model);
        
        void Remove(TDatabaseModel model);
    }
}