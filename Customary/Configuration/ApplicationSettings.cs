using System.Configuration;

namespace Custom.Configuration
{
    public static class ApplicationSettings
    {
        public static string GetApplicationSetting(string name)
        {
            return string.IsNullOrWhiteSpace(name) ? null : ConfigurationManager.AppSettings[name];
        }

        public static string GetConnectionString(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return null;

            var value = ConfigurationManager.ConnectionStrings[name];
            return value != null ? value.ToString() : null;
        }
    }
}