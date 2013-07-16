using System;
using System.Reflection;
using Autofac;
using FluentNHibernate.Cfg;
using NHibernate;
using NHibernate.Bytecode;
using RpgTome.Providers.Database;
using RpgTome.Repositories;
using Module = Autofac.Module;

namespace RpgTome.Model.Repositories
{
    public class RepositoriesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            
            builder.RegisterType<NHibernateRepository>().As<IRepository>().InstancePerLifetimeScope();

            builder.Register(ConfigureSessionFactory).As<ISessionFactory>().SingleInstance();
            builder.Register(x => x.Resolve<ISessionFactory>().OpenSession()).As<ISession>().InstancePerLifetimeScope();
        }

        private static ISessionFactory ConfigureSessionFactory(IComponentContext context)
        {
            var connectionStringProvider = context.Resolve<IConnectionStringSettings>();
            var databaseProvider = context.ResolveNamed<IDatabaseProvider>(connectionStringProvider.DatabaseProvider.ToLower());

            Console.WriteLine(string.Concat("Database Provider: ", databaseProvider));

            var databaseConfiguration = databaseProvider.GetDatabaseConfiguration(connectionStringProvider);
            var configuration =
                Fluently
                    .Configure()
                    .Database(databaseConfiguration)
                    .Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly()))
                    .ProxyFactoryFactory(typeof (DefaultProxyFactoryFactory));

            return configuration.BuildSessionFactory();
        }
    }
}
