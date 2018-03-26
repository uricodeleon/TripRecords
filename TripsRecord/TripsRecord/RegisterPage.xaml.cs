using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripsRecord.Model;
using TripsRecord.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TripsRecord
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RegisterPage : ContentPage
	{
        RegisterVM viewModel;
        public RegisterPage ()
		{
			InitializeComponent ();
            viewModel = new RegisterVM();
            BindingContext = viewModel;
        }
    }
}