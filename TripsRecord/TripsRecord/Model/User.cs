using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripsRecord.Model
{
    public class User :INotifyPropertyChanged
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;


        //create user
        public async void CreateUser(string _emailAddress,string _password,string _passwordConfirmation)
        {
            if(_password == _passwordConfirmation)
            {
                User _user = new User()
                {
                    Email = _emailAddress,
                    Password = _password
                };
                await App.MobileService.GetTable<User>().InsertAsync(_user);
               
            }
        }
        
        //Authentication
        public async Task<string> Authentication(string _email,string password)
        {
            string isAuthenticate = string.Empty;
            var user = (await App.MobileService.GetTable<User>().Where(x => x.Email == _email).ToListAsync()).FirstOrDefault();
            if(user != null)
            {
                if (user.Password == password && user.Email == _email)
                {
                    App.currentUser.Id = user.Id;
                    App.currentUser.Email = user.Email;

                    return  isAuthenticate = "1";
                }
                else
                {
                    return isAuthenticate = "2";
                }
            }else
            {
                return isAuthenticate = "3";
            }
            
         
        }
         
    }
}
