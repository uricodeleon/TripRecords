using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using TripsRecord.Model;
using TripsRecord.ViewModel.Commands;

namespace TripsRecord.ViewModel
{
    class ExperienceVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public AddExperienceCommand ExperienceCommand { get; set; }
        private Post post;

        public Post Post
        {
            get { return post; }
            set
            {
                post = value;
                OnPropertyChanged("Post");
            }
        }

        private string experience;

        public string Experience
        {
            get { return experience; }
            set
            {
                experience = value;
                Post = new Post()
                {
                    Experience = this.Experience,
                    Venue = this.Venue
                };
                OnPropertyChanged("Experience");
            }
        }

        private Venue venue;

        public Venue Venue
        {
            get { return venue; }
            set
            {
                venue = value;
                Post = new Post()
                {
                    Experience = this.Experience,
                    Venue = this.Venue
                };
                OnPropertyChanged("Venue");
            }
        }


        public ExperienceVM()
        {
            ExperienceCommand = new AddExperienceCommand(this);
            Post = new Post();
            Venue = new Venue();
        }
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public async void InsertPost(Post post)
        {
            try
            {

                Post.Insert(post);
                await App.Current.MainPage.DisplayAlert("Success", "Experience successfully inserted", "OK");
            }
            catch (NullReferenceException nre)
            {
                await App.Current.MainPage.DisplayAlert("Failure", "Experience failed to be inserted", "OK");
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Failure", "Experience failed to be inserted", "OK");
            }

        }

    }
}
