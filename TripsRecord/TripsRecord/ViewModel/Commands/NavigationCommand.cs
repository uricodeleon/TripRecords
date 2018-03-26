using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace TripsRecord.ViewModel.Commands
{
    public class NavigationCommand : ICommand
    {

        public HomeVM HomeViewModel { get; set; }

        public NavigationCommand(HomeVM homeVM)
        {
            this.HomeViewModel = homeVM;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }
        public void Execute(object parameter)
        {
            HomeViewModel.Navigate();
        }
    }
}
