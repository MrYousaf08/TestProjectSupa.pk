using SupaApp.Models;
using SupaApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SupaApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page1 : ContentPage
    {
        private string NetworkName;
        private string Code;
        public Page1()
        {
            InitializeComponent();
            string randomCode = GenerateRandomCode();
            CodeLabel.Text = $"Code: {randomCode}";
            Code= randomCode;
            // Get and display the current network name
            //string wifiSSID = DependencyService.Get<IWiFiService>().GetWifiSSID();

            //var networkInfoProvider = DependencyService.Get<INetworkInfoProvider>();
            //string networkName = networkInfoProvider.GetNetworkName();
           

        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            string wifiSSID = await DependencyService.Get<IWiFiService>().GetWifiSSIDAsync();
            NetworkLabel.Text = $"Network: {wifiSSID}";
            NetworkName = wifiSSID;
        }
        private string GenerateRandomCode()
        {
            // Generate a random 4-digit code (you can adjust the range as needed)
            Random random = new Random();
            return $"{random.Next(10000):D4}";
        }

        private async void OnNextButtonClicked(object sender, EventArgs e)
        {
            var networkConfig = new NetworkConfiguration
            {
                NetworkName = NetworkName,
                NetworkCode = Code,
            };
            App.DatabaseConnection.Insert(networkConfig);
            await Navigation.PushAsync(new Page2());
        }
    }
}