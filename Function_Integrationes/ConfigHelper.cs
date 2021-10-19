using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Function_Integrationes
{
    public static class ConfigHelper
    {
        private static Settings settings;

        public static Settings Settings
        {
            get
            {
                if (settings != null)
                {
                    return settings;
                }
                IConfigurationRoot config = new ConfigurationBuilder()
                    .AddJsonFile("local.settings.json")
                    .AddEnvironmentVariables()
                    .Build();
                settings = new Settings();
                config.Bind(settings);
                return settings;

            }
        }

    }
}
