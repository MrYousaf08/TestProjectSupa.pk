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
    public partial class Page3 : ContentPage
    {
        public Page3()
        {
            InitializeComponent();
            string randomUsername = GetRandomUsernameFromDatabase();
            WelcomeLabel.Text = $"Welcome {randomUsername}!";
        }
        private string GetRandomUsernameFromDatabase()
        {
            // Retrieve a random username from the database
            // Replace this with your actual database retrieval code
            string[] usernames = { "User1", "User2", "User3" }; // Example usernames
            Random random = new Random();
            int index = random.Next(usernames.Length);
            return usernames[index];
        }
    }
}