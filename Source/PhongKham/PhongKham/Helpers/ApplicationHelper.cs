namespace Clinic.Helpers
{
    public static class ApplicationHelper
    {
        public static string GetCurrentVersion()
        {
            var version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            return $"v{version.Major}.{version.Minor}.{version.Build}".ToLower();
        }
    }
}
