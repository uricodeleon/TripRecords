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
        public string id { get; set; }
        public string email { get; set; }
        public string password { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnProperyChanged(string propertyName)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public string Id 
        {
            get { return id; }
            set { id = value;
                OnProperyChanged("Id");
            }
        }
        public string Email
        {
            get { return email; }
            set { email = value;
                OnProperyChanged("Email");
            }
        }
        public string Password
        {
            get { return password; }
            set { password = password;
                OnProperyChanged("Password");
            }
        }


        /// <summary>
        /// Create user login
        /// </summary>
        /// <param name="_emailAddress"></param>
        /// <param name="_password"></param>
        /// <param name="_passwordConfirmation"></param>
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
