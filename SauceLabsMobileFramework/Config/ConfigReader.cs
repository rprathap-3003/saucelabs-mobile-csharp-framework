using System;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace SauceLabsMobileFramework.Config
{
    public static class ConfigReader
    {
        private static IConfigurationRoot _configuration;

        static ConfigReader()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("Config/appsettings.json", optional: false, reloadOnChange: true);

            _configuration = builder.Build();
        }

        public static string GetSauceUsername()
        {
            return Environment.GetEnvironmentVariable("SAUCE_USERNAME") 
                   ?? _configuration["SauceLabs:Username"] 
                   ?? throw new Exception("Sauce Username not found");
        }

        public static string GetSauceAccessKey()
        {
            return Environment.GetEnvironmentVariable("SAUCE_ACCESS_KEY") 
                   ?? _configuration["SauceLabs:AccessKey"] 
                   ?? throw new Exception("Sauce Access Key not found");
        }

        public static string GetSauceHubUrl()
        {
            return _configuration["SauceLabs:HubUrl"] ?? "https://ondemand.us-west-1.saucelabs.com/wd/hub";
        }

        public static IConfigurationSection GetDeviceConfig(string deviceType)
        {
            return _configuration.GetSection($"Devices:{deviceType}");
        }
    }
}
