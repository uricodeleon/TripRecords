using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using TripsRecord.Model;

namespace TripsRecord.ViewModel.Commands
{
    class AddExperienceCommand : ICommand
    {

        ExperienceVM experienceModel;
        public event EventHandler CanExecuteChanged;

        public AddExperienceCommand(ExperienceVM experienceModel)
        {
            this.experienceModel = experienceModel;
        }
   
        public bool CanExecute(object parameter)
        {
            var post = (Post)parameter;

            if (post != null)
            {
                if (string.IsNullOrEmpty(post.Experience))
                    return false;

                if (post.Venue != null)
                    return true;

                return false;
            }
            return false;
        }

        public void Execute(object parameter)
        {
            var post = (Post)parameter;
            experienceModel.InsertPost(post);
        }
    }
}
