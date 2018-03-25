using Plugin.Geolocator;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripsRecord.Logic;
using TripsRecord.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TripsRecord
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NewTripPage : ContentPage
	{
		public NewTripPage ()
		{
			InitializeComponent ();
		}

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            var locator = CrossGeolocator.Current;
            var position = await locator.GetPositionAsync();
            var venues = await Venue.GetVenues(position.Latitude, position.Longitude);

            venueListView.ItemsSource = venues; //returning list of venues.
        }

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            try
            {
                var selectedVenue = venueListView.SelectedItem as Venue;
                var firstCategory = selectedVenue.categories.FirstOrDefault();

                Post post = new Post();
                post.InsertTripPlaces(experienceEntry.Text,selectedVenue,firstCategory);
                await DisplayAlert("Success", "Experience Successfully Inserted", "Ok"); //display alert success.
                
                
                //Old Code Here.
                //Post post = new Post()
                //{
                //    Experience = experienceEntry.Text,
                //    CategoryId = firstCategory.id,
                //    CategoryName = firstCategory.name,
                //    Address = selectedVenue.location.address,
                //    Distance = selectedVenue.location.distance,
                //    Latitude = selectedVenue.location.lat,
                //    Longitude = selectedVenue.location.lng,
                //    VenueName = selectedVenue.name,
                //    userId = App.currentUser.Id
                //};

                //post.Insert(post); //pass the object here
               // await DisplayAlert("Success", "Experience Successfully Inserted", "Ok"); //display alert success.


                //SQL table Insert here
                //using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
                //{
                //    conn.CreateTable<Post>();

                //    int rows = conn.Insert(post);
                //    conn.Close();

                //    if (rows > 0)
                //        DisplayAlert("Success", "Experience Successfully Inserted", "Ok");
                //    else
                //        DisplayAlert("Failure", "Experience Failed to be Inserted", "Ok");
                //}
            }
            catch (NullReferenceException nre)
            {
               await DisplayAlert("Failure", "Experience Failed to be Inserted" + nre.ToString(), "Ok");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Failure", ex.ToString(), "Ok");
            }

            }
        
    }
}