using Android.Content;
using Android.Net.Wifi;
using NetworkExtension;
using SupaApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;

namespace SupaApp.Services.Implementations
{
    public class NetworkInfoProvider : INetworkInfoProvider
    {
        public string GetNetworkName()
        {
            // Platform-specific implementation goes here
            if (Device.RuntimePlatform == Device.iOS)
            {
                var interfaces = NEHotspotHelper.SupportedNetworkInterfaces;
                if (interfaces != null && interfaces.Length > 0)
                {
                    var ssid = interfaces[0].Ssid; // Assuming you want the first interface's SSID
                    return ssid;
                }
                return "Unknown";
                // Implement iOS network retrieval logic
                // Example: return "iOS Network Name";
            }
            else if (Device.RuntimePlatform == Device.Android)
            {
                var wifiManager = (WifiManager)Android.App.Application.Context.GetSystemService(Context.WifiService);
                var wifiInfo = wifiManager.ConnectionInfo;
                return wifiInfo.SSID;
                // Implement Android network retrieval logic
                // Example: return "Android Network Name";
            }
            else
            {
                // Other platforms (UWP, etc.) can be handled here
                return "Unknown Network Name";
            }

            // This is a fallback return statement in case none of the above conditions are met
            return "Unknown Network Name";
        }
    }
}
