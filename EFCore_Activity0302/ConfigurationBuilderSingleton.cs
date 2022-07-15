using Microsoft.Extensions.Configuration;

namespace EFCore_Activity0302
{
    public class ConfigurationBuilderSingleton
    {
        private static ConfigurationBuilderSingleton _instance = null;

        private static IConfigurationRoot _configuration;
        
        private static readonly object lockObject = new object();

        private ConfigurationBuilderSingleton()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");
            _configuration = builder.Build();
        }

        public static ConfigurationBuilderSingleton Instance
        {
            get
            {
                lock(lockObject)
                {
                    if (_instance == null)
                    {
                        _instance = new ConfigurationBuilderSingleton();
                    }
                    return _instance;
                }
            }
        }

        public static IConfigurationRoot ConfigurationRoot
        {
            get
            {
                if (_configuration == null)
                {
                    var x = Instance;
                }
                return _configuration;
            }
        }
    }
}
