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
	public partial class HistoryPage : ContentPage
	{
		public HistoryPage ()
		{
			InitializeComponent ();
		}

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            //Azure Function

            Post post = new Post();
            postListView.ItemsSource = await post.GetUserExperience();

            //Old Code
            //var posts = await App.MobileService.GetTable<Post>().Where(post => post.userId == App.currentUser.Id).ToListAsync();
            //postListView.ItemsSource = posts;

            //SQLite Function
            //SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation);
            //conn.CreateTable<Post>();
            //var posts = conn.Table<Post>().ToList();
            //postListView.ItemsSource = posts;


        }


    }
}