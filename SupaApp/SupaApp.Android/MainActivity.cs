using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using AndroidX.Core.App;
using AndroidX.Core.Content;
using Android;
using Android.Content;

namespace SupaApp.Droid
{
    [Activity(Label = "SupaApp", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize )]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        const int MY_PERMISSIONS_REQUEST_WIFI_STATE = 1;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Forms.Forms.Init(this, savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            if (ContextCompat.CheckSelfPermission(this, Manifest.Permission.AccessWifiState) != Android.Content.PM.Permission.Granted)
            {
                // Request the permission
                ActivityCompat.RequestPermissions(this, new string[] { Manifest.Permission.AccessWifiState }, MY_PERMISSIONS_REQUEST_WIFI_STATE);
            }
            CheckAndRequestPermissions();
            LoadApplication(new App());
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {

            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            if (requestCode == MY_PERMISSIONS_REQUEST_WIFI_STATE)
            {
                if (grantResults.Length > 0 && grantResults[0] == Permission.Granted)
                {
                    // Permission granted, you can proceed with your operation
                }
                else
                {
                    // Permission denied, handle this case if needed

                    // For example, show a message explaining why the permission is necessary
                    AlertDialog.Builder alertBuilder = new AlertDialog.Builder(this);
                    alertBuilder.SetTitle("Permission Denied");
                    alertBuilder.SetMessage("The app needs the phone state permission to perform this operation.");
                    alertBuilder.SetPositiveButton("Open Settings", (senderAlert, args) =>
                    {
                        OpenAppSettings(); // Method to open the app's settings page
                    });
                    alertBuilder.SetNegativeButton("Cancel", (senderAlert, args) => { });

                    AlertDialog alertDialog = alertBuilder.Create();
                    alertDialog.Show();
                }
            }
        }
        void OpenAppSettings()
        {
            Intent intent = new Intent(Android.Provider.Settings.ActionApplicationDetailsSettings);
            intent.AddFlags(ActivityFlags.NewTask);
            intent.SetData(Android.Net.Uri.FromParts("package", PackageName, null));
            StartActivity(intent);
        }

        void CheckAndRequestPermissions()
        {

            if (ContextCompat.CheckSelfPermission(this, Manifest.Permission.AccessWifiState) != Permission.Granted)
            {
                ActivityCompat.RequestPermissions(this, new string[] { Manifest.Permission.AccessWifiState }, 1);
            }
        }
    }
}