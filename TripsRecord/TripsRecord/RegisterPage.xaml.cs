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
	public partial class RegisterPage : ContentPage
	{
		public RegisterPage ()
		{
			InitializeComponent ();
		}

        private async void registerButton_Clicked(object sender, EventArgs e)
        {
            if (passwordEntry.Text == confirmPasswordEntry.Text)
            {
                User user = new User();
                user.CreateUser(emailEntry.Text, passwordEntry.Text, confirmPasswordEntry.Text);
                await DisplayAlert("Success", "User Successfully Created!", "Ok");
                await Navigation.PushAsync(new MainPage());
            }
            else
            {
               await DisplayAlert("Error", "Password don't match!", "Ok");
            }
        }

    }
}