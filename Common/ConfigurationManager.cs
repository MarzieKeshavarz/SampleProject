using Microsoft.Extensions.Configuration;

namespace Common
{
    public static class ConfigurationManager
    {
        public static IConfiguration Configuration { private get; set; }

        public static string GetValue(string index)
        {
            return GetValue<string>(index);
        }

        public static T GetValue<T>(string key)
        {
            return Configuration.GetValue<T>(key);
        }

        public static IConfiguration GetConfiguration()
        {
            return Configuration;
        }
    }
}
