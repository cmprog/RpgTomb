using System;
using System.Data;
using FluentNHibernate.Cfg.Db;
using RpgTome.Repositories;

namespace RpgTome.Providers.Database
{
    public interface IDatabaseProvider
    {
        string DefaultConnectionString { get; }
        bool SupportSchema { get; }
        bool SupportFuture { get; }
        bool SupportsFullText { get; }

        /// <summary>
        /// Tries to connect to the database.
        /// </summary>
        /// <param name="connectionString">The connection string.</param>
        /// <param name="errorMessage">Any error message encountered.</param>
        /// <returns></returns>
        bool TryConnect(string connectionString, out string errorMessage);

        IPersistenceConfigurer GetDatabaseConfiguration(IConnectionStringSettings connectionStringSettings);
        Func<IDbConnection> GetConnectionFactory(string connectionString);
    }
}
