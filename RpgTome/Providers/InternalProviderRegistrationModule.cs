using Autofac;
using Autofac.Features.Indexed;
using RpgTome.Providers.Database;
using RpgTome.Repositories;

namespace RpgTome.Providers
{
    public class InternalProviderRegistrationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            RegisterDatabaseProviders(builder);
        }

        private static void RegisterDatabaseProviders(ContainerBuilder builder)
        {
            builder
                .RegisterType<SqlDatabaseProvider>()
                .Named<IDatabaseProvider>("sql");

            builder
                .Register(ProviderInfo.For<IDatabaseProvider>)
                .As<IProviderInfo<IDatabaseProvider>>()
                .SingleInstance();

            builder.Register(
                c =>
                {
                    var providerLookup = c.Resolve<IIndex<string, IDatabaseProvider>>();
                    var databaseProvider = c.Resolve<IConnectionStringSettings>().DatabaseProvider.ToLower();
                    return providerLookup[databaseProvider];
                })
                .As<IDatabaseProvider>()
                .InstancePerLifetimeScope();
        }
    }
}
