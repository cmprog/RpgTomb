using RpgTome.Repositories;

namespace RpgTome.Settings
{
    public class ConnectionStringSettings : IConnectionStringSettings
    {
        private readonly IConfigSettings mSettings;
        private readonly IAppHarborSettings mAppHarborSettings;

        public ConnectionStringSettings(IConfigSettings settings, IAppHarborSettings appHarborSettings)
        {
            this.mSettings = settings;
            this.mAppHarborSettings = appHarborSettings;
        }

        public string ConnectionString
        {
            get { return mAppHarborSettings.SqlServerConnectionString ?? mSettings.Get("rpgtome.configuration.database.connection"); }
            set
            {
                if (mAppHarborSettings.SqlServerConnectionString != null)
                    mAppHarborSettings.SqlServerConnectionString = value;
                else
                    mSettings.Set("rpgtome.configuration.database.connection", value);
            }
        }

        public string Schema
        {
            get { return mSettings.Get("rpgtome.configuration.database.schema"); }
            set { mSettings.Set("rpgtome.configuration.database.schema", value); }
        }

        public string ReadOnlyReason
        {
            get { return mSettings.ReadOnlyReason; }
        }

        public string DatabaseProvider
        {
            get { return (mSettings.Get("rpgtome.configuration.database.provider") ?? "sql").ToLower(); }
            set { mSettings.Set("rpgtome.configuration.database.provider", value); }
        }
    }
}
