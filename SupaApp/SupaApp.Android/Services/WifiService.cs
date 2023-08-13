using Android.App;
using Android.Content;
using Android.Net.Wifi;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SupaApp.Droid.Services;
using SupaApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(WifiService))]
namespace SupaApp.Droid.Services
{
    public class WifiService : IWiFiService
    {
        public async Task<string> GetWifiSSIDAsync()
        {
            string ssid = "Not Connected";

            try
            {
                WifiManager wifiManager = (WifiManager)Android.App.Application.Context.GetSystemService(Context.WifiService);
                WifiInfo wifiInfo = wifiManager.ConnectionInfo;

                if (wifiInfo != null)
                {
                    ssid = wifiInfo.SSID.Replace("\"", ""); // Remove quotes around SSID
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions if needed
            }

            return ssid;
        }
    }
}