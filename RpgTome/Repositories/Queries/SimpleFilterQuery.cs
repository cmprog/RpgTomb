using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using NHibernate;
using RpgTome.Providers.Database;

namespace RpgTome.Repositories.Queries
{
    public sealed class SimpleFilterQuery<TEntity> : IQuery<TEntity> where TEntity : class
    {
        private readonly Expression<Func<TEntity, bool>> mFilterExpression;

        public SimpleFilterQuery(Expression<Func<TEntity, bool>> filterExpression)
        {
            if (filterExpression == null) throw new ArgumentNullException("filterExpression");
            this.mFilterExpression = filterExpression;
        }

        public IEnumerable<TEntity> Execute(ISession session, IDatabaseProvider databaseProvider)
        {
            return session.QueryOver<TEntity>().Where(this.mFilterExpression).List();
        }
    }
}
