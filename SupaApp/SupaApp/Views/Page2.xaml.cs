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
    public partial class Page2 : ContentPage
    {
        private string NetworkName;
        public Page2()
        {
            InitializeComponent();
        }
        private async void OnBackButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            string wifiSSID = await DependencyService.Get<IWiFiService>().GetWifiSSIDAsync();
            NetworkLabel.Text = $"Network: {wifiSSID}";
            NetworkName= wifiSSID;
        }
        private async void OnSubmitButtonClicked(object sender, EventArgs e)
        {
            // Retrieve the stored code and network name from the database
            //string storedCode = GetStoredCodeFromDatabase();
            //string storedNetworkName = GetStoredNetworkNameFromDatabase();
            var networkConfigurations = App.DatabaseConnection.Table<NetworkConfiguration>().ToList();
            string networkLabelName = NetworkName; // Replace with the actual value you're using for NetworkLabelName

            bool foundMatch = networkConfigurations.Any(nc =>
                nc.NetworkName.Equals(networkLabelName, StringComparison.OrdinalIgnoreCase) &&
                nc.NetworkCode == CodeEntry.Text);

            if (foundMatch)
            {
                await Navigation.PushAsync(new Page3());
            }
            else
            {
                await DisplayAlert("Error", "Code and network do not match.", "OK");
            }

        }

        private string GetStoredCodeFromDatabase()
        {
            // Retrieve the stored code from the database
            // Replace this with your actual database retrieval code
            return "4F6I"; // Example code
        }

        private string GetStoredNetworkNameFromDatabase()
        {
            // Retrieve the stored network name from the database
            // Replace this with your actual database retrieval code
            return "YourNetworkName"; // Example network name
        }
    }
}