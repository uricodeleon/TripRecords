﻿using Plugin.Geolocator;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripsRecord.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TripsRecord
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MapPage : ContentPage
	{
		public MapPage ()
		{
			InitializeComponent ();
		}

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            var locator = CrossGeolocator.Current;

            if (!locator.IsListening) {
                locator.PositionChanged += Locator_PositionChanged;
                await locator.StartListeningAsync(TimeSpan.FromSeconds(0), 100);
                var position = await locator.GetPositionAsync();
            }
        }

        private async void Locator_PositionChanged(object sender, Plugin.Geolocator.Abstractions.PositionEventArgs e)
        {
            var center = new Xamarin.Forms.Maps.Position(e.Position.Latitude, e.Position.Longitude);
            var span = new Xamarin.Forms.Maps.MapSpan(center, 2, 2);
            locationsMap.MoveToRegion(span);


            Post post = new Post();
            await post.GetPlaceExperience(locationsMap);
            
            //Azure Function
           
            //Old Code
            //var posts = await App.MobileService.GetTable<Post>().Where(post => post.userId == App.currentUser.Id).ToListAsync();
            //DisplayInMap(posts);

            //SQL Function Here
            //using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            //{
            //    conn.CreateTable<Post>();
            //    var posts = conn.Table<Post>().ToList();
            //    DisplayInMap(posts);
            //}
        }

        //private void DisplayInMap(List<Post> posts)
        //{
        //    foreach (var post in posts)
        //    {
        //        try
        //        {
        //            var position = new Xamarin.Forms.Maps.Position(post.Latitude, post.Longitude);

        //            var pin = new Xamarin.Forms.Maps.Pin()
        //            {
        //                Type = Xamarin.Forms.Maps.PinType.SavedPin,
        //                Position = position,
        //                Label = post.VenueName,
        //                Address = post.Address
        //            };
        //            locationsMap.Pins.Add(pin);
        //        }
        //        catch (NullReferenceException nre) { }
        //        catch (Exception ex) { }
        //    }
        //}
    }
}