using Newtonsoft.Json;
using SQLite;
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
        private string id;

        public string Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }

        private string email;

        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                OnPropertyChanged("Email");
            }
        }

        private string password;

        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                OnPropertyChanged("Password");
            }
        }

        private string confirmPassword;
        public string ConfirmPassword
        {
            get { return confirmPassword; }
            set
            {
                confirmPassword = value;
                OnPropertyChanged("ConfirmPassword");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Creating new user
        /// </summary>
        /// <param name="_user"></param>
        public async void CreateUser(User _user)
        {       
            await App.MobileService.GetTable<User>().InsertAsync(_user);

        }
        /// <summary>
        /// Login Authentication
        /// For Users
        /// </summary>
        /// <param name="_email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
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
                    return isAuthenticate = "1";
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
