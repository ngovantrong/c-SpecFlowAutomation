using System;
using System.Collections.Specialized;
using Microsoft.Extensions.Configuration;
using TechTalk.SpecFlow;

namespace FINWebUIAutomation.Support
{
    [Binding]
    internal static class TestConfiguration
    {
        private static readonly IConfiguration Configuration;
        public static NameValueCollection AppSettings { get; }

        static TestConfiguration()
        {
            var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json");

            Configuration = builder.Build();
        }

        public static string GetSectionAndValue(string sectionName, string value)
        {
            if (sectionName == "Settings")
            {
                var devEnv = TestConfiguration.GetSectionAndValue("Environment", "Tienp_Dev");
                var stagingEnv = TestConfiguration.GetSectionAndValue("Environment", "Staging");
                var prodEnv = TestConfiguration.GetSectionAndValue("Environment", "Production");

                if (devEnv == "true" && stagingEnv != "true" && prodEnv != "true")
                {
                    return Configuration.GetSection("Tienp_Dev")[value];
                }
                else if (devEnv != "true" && stagingEnv == "true" && prodEnv != "true")
                {
                    return Configuration.GetSection("Staging")[value];
                }
                else if (devEnv != "true" && stagingEnv != "true" && prodEnv == "true")
                {
                    return Configuration.GetSection("Production")[value];
                }
                else
                    return Configuration.GetSection("Tienp_Dev")[value];
            }

            return Configuration.GetSection(sectionName)[value];
        }

        public static object GetSection(string sectionName)
        {
            return Configuration.GetSection(sectionName);
        }

        internal static string GetSecretValue(string v)
        {
            throw new NotImplementedException();
        }
    }
}