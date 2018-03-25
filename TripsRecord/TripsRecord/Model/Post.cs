using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.Maps;

namespace TripsRecord.Model
{
    public class Post
    {
        [PrimaryKey, AutoIncrement]
        public string Id { get; set; }
        [MaxLength(250)]
        public string Experience { get; set; }
        public string VenueName { get; set; }
        public string CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Address { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int Distance { get; set; }
        public string userId { get; set; }


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
            _post = await post;
            return await post;
        }

        //Get The place Experience
        public async Task<List<Post>> GetPlaceExperience(Map map)
        {
            List<Post> _post = new List<Post>();
            var posts = await App.MobileService.GetTable<Post>().Where(post => post.userId == App.currentUser.Id).ToListAsync();
            _post = posts;
            DisplayInMap(_post, map);
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

             post.Insert(post); //pass the object here
            await Task.Delay(10);
        }
    }
}
