using System.Configuration;

namespace Clinic.Helpers
{
    public static class Setting
    {
        public static bool UpdateDatabase = bool.Parse(ConfigurationManager.AppSettings["updatedatabase"]);

        public static bool SslModeDatabase = bool.Parse(ConfigurationManager.AppSettings["SslModeDatabase"]);
    }
}
