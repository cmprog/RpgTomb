using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using RpgTome.Providers.Database;

namespace RpgTome.Repositories
{
    public interface IPagedQuery<T>
    {
        PagedResult<T> Execute(ISession session, IDatabaseProvider databaseProvider, int skip, int take);
    }
}
