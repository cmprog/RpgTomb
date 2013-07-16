using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using RpgTome.Providers.Database;

namespace RpgTome.Repositories
{
    public class NHibernateRepository : IRepository
    {
        private readonly ISession mSession;
        private readonly Func<IDatabaseProvider> mDatabaseProvider;

        public NHibernateRepository(ISession session, Func<IDatabaseProvider> databaseProvider)
        {
            this.mSession = session;
            this.mDatabaseProvider = databaseProvider;
        }

        public TEntity Get<TEntity>(object id)
        {
            return mSession.Get<TEntity>(id);
        }

        public IEnumerable<TEntity> FindAll<TEntity>() where TEntity : class
        {
            return mSession
                .QueryOver<TEntity>()
                .List<TEntity>();
        }

        public IEnumerable<TEntity> Find<TEntity>(IQuery<TEntity> query) where TEntity : class
        {
            return query.Execute(mSession, mDatabaseProvider());
        }

        public PagedResult<TEntity> Find<TEntity>(IPagedQuery<TEntity> query, int pageNumber, int itemsPerPage) where TEntity : class
        {
            var skip = pageNumber * itemsPerPage;
            return query.Execute(mSession,
                mDatabaseProvider(),
                skip, itemsPerPage);
        }

        public TEntity FindFirst<TEntity>(IQuery<TEntity> query) where TEntity : class
        {
            return One(Find(query), true);
        }

        public TEntity FindFirstOrDefault<TEntity>(IQuery<TEntity> query) where TEntity : class
        {
            return One(Find(query), false);
        }

        public TEntity FindFirstOrDefault<TEntity>(IPagedQuery<TEntity> query) where TEntity : class
        {
            return One(Find(query, 0, 1), false);
        }

        public void Execute(ICommand command)
        {
            command.Execute(mSession);
        }

        public void Add(object entity)
        {
            mSession.Persist(entity);
        }

        public void Remove(object entity)
        {
            mSession.Delete(entity);
        }

        private T One<T>(IEnumerable<T> items, bool throwIfNone)
        {
            var itemsList = items.Take(2).ToList();
            if (throwIfNone && itemsList.Count == 0)
            {
                throw new Exception(string.Format("Expected at least one '{0}' in the query results", typeof(T).Name));
            }
            return itemsList.Count > 0
                       ? itemsList[0]
                       : default(T);
        }
    }
}
