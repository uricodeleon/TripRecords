using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripsRecord.Model;
using TripsRecord.ViewModel;
using TripsRecord.ViewModel.Commands;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TripsRecord
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HistoryPage : ContentPage
    {
        HistoryVM viewModel;
        public HistoryPage ()
		{
			InitializeComponent ();
            viewModel = new HistoryVM();
            BindingContext = viewModel;
        }

        protected  override void OnAppearing()
        {
            base.OnAppearing();
             viewModel.UpdatePosts();
            //Azure Function

            //var posts = await Post.Read();
            //postListView.ItemsSource = posts;

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