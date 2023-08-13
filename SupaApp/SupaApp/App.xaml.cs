using SQLite;
using SupaApp.Models;
using SupaApp.Views;
using System;
using System.IO;
using Xamarin.Forms;

namespace SupaApp
{
    public partial class App : Application
    {
        public static SQLiteConnection DatabaseConnection;
        public App()
        {
            InitializeComponent();

            string databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "networkconfig.db3");
            DatabaseConnection = new SQLiteConnection(databasePath);
            DatabaseConnection.CreateTable<NetworkConfiguration>();
            MainPage = new NavigationPage(new Page1());
        }

        protected override void OnStart()
        {

        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
