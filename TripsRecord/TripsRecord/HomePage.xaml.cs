using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripsRecord.ViewModel.Commands;
using TripsRecord.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TripsRecord
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HomePage : TabbedPage
	{
        HomeVM homeView;
		public HomePage ()
		{
			InitializeComponent ();
            homeView = new HomeVM();
		}

        //private void ToolbarItem_Clicked(object sender, EventArgs e)
        //{
        //    Navigation.PushAsync(new NewTripPage());
        //}
    }
}