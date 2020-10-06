using System;
using System.Linq;
using Autofac;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Vigie.Risques.Tpm.Core.Configuration;
using Vigie.Risques.Tpm.Core.Services;
using Vigie.Risques.Tpm.Core.Services.Contracts;
using Sword.Swl.Framework.Xamarin.Models;
using Sword.Swl.Framework.Xamarin.Services;
using Sword.Swl.Framework.Xamarin.Services.Contracts;
using Xamarin.Forms;

namespace Vigie.Risques.Tpm.Core
{
    public partial class App : Application
    {
        public App(Action<ContainerBuilder> platformSpecificRegistration)
        {
            InitializeComponent();

            var builder = new ContainerBuilder();

            // Ajouter l'enregistrement des services non-sp�cifiques aux plateformes ici
            builder.RegisterType<AppCenterLogServiceProvider>().InstancePerLifetimeScope().As<ILogProvider>();
            builder.RegisterType<AppCenterLogService>().InstancePerLifetimeScope().As<ILog>();
            builder.RegisterType<NavigationService>().InstancePerLifetimeScope().As<INavigationService>();
            builder.RegisterType<ViewModelManager>().InstancePerLifetimeScope().As<IViewModelManager>();
            builder.RegisterType<AkavacheCacheService>().InstancePerLifetimeScope().As<ICacheService>();

            // ViewModel registration
            builder.RegisterTypes(
                System.Reflection.Assembly.GetExecutingAssembly()
                    .GetTypes()
                    .Where(t => t.Name.EndsWith("ViewModel"))
                    .ToArray());

            platformSpecificRegistration?.Invoke(builder);

            Sword.Swl.Framework.Xamarin.Extensions.TranslateExtension.Init<Resources.Labels>();

            Container = builder.Build().BeginLifetimeScope();
        }

        public static ILifetimeScope Container { get; private set; }

        protected async override void OnStart()
        {
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

            await App.Container.Resolve<INavigationService>().InitializeAsync<ViewModels.MasterDetailsViewModel>(App.Container);

            Microsoft.AppCenter.AppCenter.Start(
                GetAppCenterSecret(),
                typeof(Analytics),
                typeof(Crashes));
        }

        protected override void OnSleep()
        {
            AppDomain.CurrentDomain.UnhandledException -= CurrentDomain_UnhandledException;

            DependencyService.Get<ICacheService>().Shutdown().Wait();
        }

        protected override void OnResume()
        {
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
        }

        private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            var debugTrace = DependencyService.Get<ILog>();
            if (debugTrace == null)
            {
                System.Diagnostics.Debug.WriteLine("Vigie.Risques.Tpm : Error : " + e.ExceptionObject.ToString());
            }
            else
            {
                debugTrace.Log(LogLevel.Error, () => "Vigie.Risques.Tpm start", e.ExceptionObject as Exception);
            }
        }

        private static string GetAppCenterSecret()
        {
            return $"android={Config.AppConfig.AppCenterAndroidAppId};ios={Config.AppConfig.AppCenterIosAppId}";
        }
    }
}
