using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using RpgTome.Providers.Database;

namespace RpgTome.Repositories
{
    public interface IQuery<out TResult>
    {
        IEnumerable<TResult> Execute(ISession session, IDatabaseProvider databaseProvider);
    }
}
