using System;
using System.IO;
using System.Linq;
using Xamarin.UITest;
using Xamarin.UITest.Configuration;
using Xamarin.UITest.Queries;

namespace Vigie.Risques.Tpm.UITests
{
    public static class AppInitializer
    {
        static AppInitializer()
        {
#if ENV_DEV
            EnvSuffix = ".dev";
#elif ENV_INT
            EnvSuffix = ".inte";
#else
            EnvSuffix = string.Empty;
#endif
        }

        private static string EnvSuffix { get; set; }

        public static IApp StartApp(Platform platform)
        {
            if (platform == Platform.Android)
            {
                return ConfigureApp
                    .Android
                    .InstalledApp("com.vigie.risques.tpm" + EnvSuffix)
                    .EnableLocalScreenshots()
                    .StartApp(AppDataMode.DoNotClear);
            }

            return ConfigureApp
                .iOS
                .InstalledApp("com.Vigie.Risques.Tpm" + EnvSuffix)
                .EnableLocalScreenshots()
                .StartApp(AppDataMode.DoNotClear);
        }
    }
}

