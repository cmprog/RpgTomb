using Autofac;
using RpgTome.Repositories;

namespace RpgTome.Settings
{
    public class SettingsModule : Module
    {
        private readonly string mBootstrapSettingsFilePath;

        public SettingsModule(string bootstrapSettingsFilePath)
        {
            this.mBootstrapSettingsFilePath = bootstrapSettingsFilePath;
        }

        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<ConnectionStringSettings>()
                .As<IConnectionStringSettings>()
                .SingleInstance();

            // This is for Azure connection string support, needs more thought on how to adapt/detect Azure
            //builder.Register(c => new ConfigSettingsAdapter(new XmlConfigSettings(bootstrapSettingsFilePath)))
            builder.Register(c => new XmlConfigSettings(mBootstrapSettingsFilePath))
                .As<IConfigSettings>()
                .SingleInstance();

            builder.RegisterType<AppHarborSettings>()
                .As<IAppHarborSettings>()
                .SingleInstance();
        }
    }
}
