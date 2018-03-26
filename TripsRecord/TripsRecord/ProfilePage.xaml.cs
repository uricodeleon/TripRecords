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
	public partial class ProfilePage : ContentPage
	{
		public ProfilePage ()
		{
			InitializeComponent ();
		}
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            var postTable = await Post.Read();
            var categoriesCount = Post.PostCategories(postTable);

            //Azure
            var _postTable = await App.MobileService.GetTable<Post>().Where(x => x.Id == App.currentUser.Id).ToListAsync();
            categoriesListView.ItemsSource = categoriesCount;
            postCountLabel.Text = _postTable.Count.ToString();


            //old code
            //var categories = _postTable.OrderBy(x => x.CategoryId).Select(x => x.CategoryName).Distinct().ToList();

            //Dictionary<string, int> categoriesCount = new Dictionary<string, int>();

            //foreach (var category in categories)
            //{
            //    var count = _postTable.Where(x => x.CategoryName == category).ToList().Count();
            //    categoriesCount.Add(category, count);
            //}




            //SQL function
            //using(SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            //{
            //    var _postTable = conn.Table<Post>().ToList();
            //    var categories = _postTable.OrderBy(x => x.CategoryId).Select(x => x.CategoryName).Distinct().ToList();


            //    Dictionary<string, int> categoriesCount = new Dictionary<string, int>();

            //    foreach(var category in categories)
            //    {
            //        //LinQ
            //        //var count = (from post in _postTable
            //        //             where post.CategoryName == category
            //        //             select post).ToList().Count();

            //        //LinQ Lambda Expression

            //        var count = _postTable.Where(x => x.CategoryName == category).ToList().Count();
            //        categoriesCount.Add(category, count);
            //    }
            //    categoriesListView.ItemsSource = categoriesCount;
            //    postCountLabel.Text = _postTable.Count.ToString();
            //}
        }
    }
}