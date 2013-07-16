using System.Configuration;
using System.Web.Configuration;

namespace RpgTome.Settings
{
    public class AppHarborSettings : IAppHarborSettings
    {
        public string SqlServerConnectionString
        {
            get
            {
                var apphbConnectionString = ConfigurationManager.AppSettings["SQLSERVER_CONNECTION_STRING"];

                if (string.IsNullOrWhiteSpace(apphbConnectionString))
                    return null;

                return apphbConnectionString;
            }
            set
            {
                var config = WebConfigurationManager.OpenWebConfiguration("~");
                config.AppSettings.Settings["SQLSERVER_CONNECTION_STRING"].Value = value;
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
            }
        }
    }
}