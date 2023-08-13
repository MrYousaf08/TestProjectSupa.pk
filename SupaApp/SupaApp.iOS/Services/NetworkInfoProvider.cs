using Foundation;
using NetworkExtension;
using SupaApp.iOS.Services;
using SupaApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(NetworkInfoProvider))]
namespace SupaApp.iOS.Services
{
    public class NetworkInfoProvider : INetworkInfoProvider
    {
        public string GetNetworkName()
        {
            var interfaces = NEHotspotHelper.SupportedNetworkInterfaces;
            if (interfaces != null && interfaces.Length > 0)
            {
                var ssid = interfaces[0].Ssid; // Assuming you want the first interface's SSID
                return ssid;
            }
            return "Unknown";
        }
    }
}