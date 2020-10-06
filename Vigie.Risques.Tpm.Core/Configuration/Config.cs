using System;
using System.Collections.Generic;
using System.Text;

namespace Vigie.Risques.Tpm.Core.Configuration
{
    public static class Config
    {
        static Config()
        {
            IConfig config = null;

#if ENV_INT
            config = new ConfigInt();
#elif ENV_PROD
            config = new ConfigProd();
#else
            config = new ConfigDev();
#endif

            AppConfig = config;
        }

        public static IConfig AppConfig { get; private set; }
    }
}
