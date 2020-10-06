using System.Threading;
using Android.App;
using Android.Content.PM;
using Android.OS;
using Vigie.Risques.Tpm.Core;

namespace Vigie.Risques.Tpm.Droid
{
    [Activity(
        Label = "Vigie.Risques.Tpm",
        Icon = "@drawable/icon",
        Theme = "@style/MainTheme",
        ScreenOrientation = ScreenOrientation.Portrait,
        MainLauncher = true,
        ConfigurationChanges = ConfigChanges.ScreenSize)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            Thread.CurrentThread.CurrentCulture = Thread.CurrentThread.CurrentUICulture = System.Globalization.CultureInfo.GetCultureInfo("fr-FR");

            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;
            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App(null));
        }
    }
}
