using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripsRecord.Model;
using Xamarin.Forms;
using TripsRecord.ViewModel.Commands;
using TripsRecord.ViewModel;

namespace TripsRecord
{
	public partial class MainPage : ContentPage
	{
        MainVM viewModel;
        public MainPage()
		{
			InitializeComponent();

            var assembly = typeof(MainPage);

            viewModel = new MainVM();
            BindingContext = viewModel;
            iconImage.Source = ImageSource.FromResource("TripsRecord.Assets.Images.saitama_1x.png", assembly);
		}

        //private async void loginButton_Clicked(object sender, EventArgs e)
        //{
        //    bool isEmailEmpty = string.IsNullOrEmpty(emailEntry.Text);
        //    bool isPasswordEmpty = string.IsNullOrEmpty(passwordEntry.Text);
            
        //    if (isEmailEmpty || isPasswordEmpty)
        //       {

        //       }
        //    else
        //    {

        //        User user = new User();

        //        if(await user.Authentication(emailEntry.Text,passwordEntry.Text) == "1")
        //        {
        //            await Navigation.PushAsync(new HomePage());

        //        }else if(await user.Authentication(emailEntry.Text, passwordEntry.Text) == "2") 
        //        {
        //            await DisplayAlert("Error", "Invalid Email and Password", "Ok");

        //        }else
        //        {
        //            await DisplayAlert("Error", "Email and Password is not Exist", "Ok");
        //        }

        //        //var user = (await App.MobileService.GetTable<User>().Where(x => x.Email == emailEntry.Text).ToListAsync()).FirstOrDefault();
        //        //if (user != null)
        //        //{

        //        //    if (user.Password == passwordEntry.Text && user.Email == emailEntry.Text)
        //        //    {
        //        //        App.currentUser.Id = user.Id;
        //        //        App.currentUser.Email = user.Email;
        //        //        await Navigation.PushAsync(new HomePage());
        //        //    }
        //        //    else
        //        //    {
        //        //        await DisplayAlert("Error", "Invalid Email and Password", "Ok");
        //        //    }
        //        //}
        //        //else
        //        //{
        //        //    await DisplayAlert("Error", "Email and Password is not Exist", "Ok");
        //        //}
        //       }
            
        //}

        //private void registerButton_Clicked(object sender, EventArgs e)
        //{
        //    Navigation.PushAsync(new RegisterPage());
        //}

    }
}
