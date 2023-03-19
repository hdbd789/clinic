using System.Configuration;

namespace Clinic.Data.Setting
{
    public static class DatabaseSetting
    {
        public static bool SslModeDatabase = bool.Parse(ConfigurationManager.AppSettings["SslModeDatabase"]);

        public static string DatabaseName = ConfigurationManager.AppSettings["databasename"];
    }
}
