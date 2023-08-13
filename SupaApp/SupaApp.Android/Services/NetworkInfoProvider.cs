using Android.App;
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
using Android.Content;
using Xamarin.Forms;


[assembly: Dependency(typeof(NetworkInfoProvider))]
namespace SupaApp.Droid.Services
{
    public class NetworkInfoProvider : INetworkInfoProvider
    {
        [Obsolete]
        public string GetNetworkName()
        {
            var wifiManager = (WifiManager)Android.App.Application.Context.GetSystemService(Context.WifiService);
            var wifiInfo = wifiManager.ConnectionInfo;
            return wifiInfo.SSID;
        }
    }
}