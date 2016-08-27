using Android.App;
using Android.Content.PM;
using Android.OS;
using Xamarin.Forms.Platform.Android;
using HockeyApp.Android;
using HockeyApp.Android.Metrics;

namespace CoffeeTip.Droid
{
    [Activity(Label = "CoffeeTip.Droid", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            CheckForUpdates();
            CrashManager.Register(this, "22d766eb2f414b4d8195f6f2b1610de5");
            MetricsManager.Register(this, Application, "22d766eb2f414b4d8195f6f2b1610de5");



            global::Xamarin.Forms.Forms.Init(this, bundle);

            Xamarin.Forms.Forms.ViewInitialized += (sender,  e) => 
                {
                    if (!string.IsNullOrWhiteSpace(e.View.StyleId)) 
                    {
                        e.NativeView.ContentDescription = e.View.StyleId;
                    }
                };

            FormsAppCompatActivity.ToolbarResource = Resource.Layout.toolbar;
            FormsAppCompatActivity.TabLayoutResource = Resource.Layout.tabs;

            LoadApplication(new App());
        }
        private void CheckForUpdates()
        {
            // Remove this for store builds!
            UpdateManager.Register(this, "22d766eb2f414b4d8195f6f2b1610de5");
        }

        private void UnregisterManagers()
        {
            UpdateManager.Unregister();
        }

        protected override void OnPause()
        {
            base.OnPause();
            UnregisterManagers();
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            UnregisterManagers();
        }
    }
}

