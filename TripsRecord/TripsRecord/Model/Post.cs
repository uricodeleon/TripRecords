using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.Maps;

namespace TripsRecord.Model
{
    public class Post :INotifyPropertyChanged
    {
        //[PrimaryKey, AutoIncrement]
        //public string Id { get; set; }
        //[MaxLength(250)]
        //public string Experience { get; set; }
        //public string VenueName { get; set; }
        //public string CategoryId { get; set; }
        //public string CategoryName { get; set; }
        //public string Address { get; set; }
        //public double Latitude { get; set; }
        //public double Longitude { get; set; }
        //public int Distance { get; set; }
        //public string userId { get; set; }

        public string id;
        public string experience = string.Empty;
        public string venueName = string.Empty;
        public string categoryId = string.Empty;
        public string categoryName = string.Empty;
        public string address = string.Empty;
        public double latitude;
        public double longitude;
        public int distance = 0;
        public string userId { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnProperyChanged(string propertyName)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public string Id
        {
            get { return id; }
            set
            {
                id = value;
                OnProperyChanged("Id");
            }
        }
        public string Experience
        {
            get { return experience; }
            set
            {
                experience = value;
                OnProperyChanged("Experience");
            }
        }
        public string VenueName
        {
            get { return venueName; }
            set
            {
                venueName = value;
                OnProperyChanged("VenueName");
            }
        }
        public string CategoryId
        {
            get { return categoryId; }
            set
            {
                categoryId = value;
                OnProperyChanged("CategoryId");
            }
        }
        public string CategoryName
        {
            get { return categoryName; }
            set
            {
                categoryName = value;
                OnProperyChanged("CategoryName");
            }
        }
        public string Address
        {
            get { return address; }
            set
            {
                address = value;
                OnProperyChanged("Address");
            }
        }
        public double Latitude
        {
            get { return latitude; }
            set
            {
                latitude = value;
                OnProperyChanged("Latitude");
            }
        }
        public double Longitude
        {
            get { return longitude; }
            set
            {
                longitude = value;
                OnProperyChanged("Longitude");
            }
        }
        public int Distance
        {
            get { return distance; }
            set
            {
                distance = value;
                OnProperyChanged("Distance");
            }
        }
        public string UserId
        {
            get { return userId; }
            set
            {
                userId = value;
                OnProperyChanged("UserId");
            }
        }

        //insert data to post table
        public async void Insert(Post post)
        {
            await App.MobileService.GetTable<Post>().InsertAsync(post);
        }

        //get the user's experience 
        //base on user's id
        public async Task<List<Post>> GetUserExperience()
        {
            List<Post> _post = new List<Post>();
            var post = App.MobileService.GetTable<Post>().Where(x => x.userId == App.currentUser.Id).ToListAsync();

            if (_post !=null) {          
                _post = await post;              
            }
            return await post;
        }

        //Get The place Experience
        public async Task<List<Post>> GetPlaceExperience(Map map)
        {
            List<Post> _post = new List<Post>();

            if (_post !=null) {
                var posts = await App.MobileService.GetTable<Post>().Where(post => post.userId == App.currentUser.Id).ToListAsync();
                _post = posts;
                DisplayInMap(_post, map);
               
            }
            return _post;
        }

        //Get Count of User visited place and experience
        public async Task<Dictionary<string,int>> CategoryCount()
        {
            var _postTable = await App.MobileService.GetTable<Post>().Where(post => post.userId == App.currentUser.Id).ToListAsync();
            var categories = _postTable.OrderBy(x => x.CategoryId).Select(x => x.CategoryName).Distinct().ToList();

            Dictionary<string, int> categoriesCount = new Dictionary<string, int>();

            foreach (var category in categories)
            {
                var count = _postTable.Where(x => x.CategoryName == category).ToList().Count();
                categoriesCount.Add(category, count);
            }
            return categoriesCount;
        }


        //Display the map pin in the 
        //visited places or areas
        public async void DisplayInMap(List<Post> _post, Map _location)
        {
            foreach (var post in _post)
            {
                try
                {
                    var position =  new Xamarin.Forms.Maps.Position(post.Latitude, post.Longitude);
                    var pin = new Xamarin.Forms.Maps.Pin()
                    {
                        Type = Xamarin.Forms.Maps.PinType.SavedPin,
                        Position = position,
                        Label = post.VenueName,
                        Address = post.Address
                    };
                    _location.Pins.Add(pin);
                }
                catch (NullReferenceException nre) { }
                catch (Exception ex) { }
            }
            await Task.Delay(20);
        }
        public async void InsertTripPlaces(string _experience,Venue _venue, Category firstCategory)
        {
            Post post = new Post()
            {
                Experience = _experience,
                CategoryId = firstCategory.id,
                CategoryName = firstCategory.name,
                Address = _venue.location.address,
                Distance = _venue.location.distance,
                Latitude = _venue.location.lat,
                Longitude = _venue.location.lng,
                VenueName = _venue.name,
                userId = App.currentUser.Id
            };

             post.Insert(post); 
             await Task.Delay(10);
        }
    }
}
