using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TripsRecord.Model;
using Xamarin.Forms;

namespace TripsRecord
{
	public partial class App : Application
	{
        public static string DatabaseLocation = string.Empty;


        //database name from azure
        public static MobileServiceClient MobileService =
            new MobileServiceClient(
            "https://mikkotrips.azurewebsites.net"
            );

        public static User currentUser = new User();


        public App ()
		{
			InitializeComponent();

			MainPage = new NavigationPage(new MainPage());
		}

        public App(string databaseLocation)
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());

            DatabaseLocation = databaseLocation;
        }

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
