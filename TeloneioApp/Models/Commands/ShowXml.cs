using System;
using System.Windows.Input;
using TeloneioApp.ViewModels;

namespace TeloneioApp.Models.Commands
{
    public class ShowXml : ICommand
    {
        public ImportFormViewModel MainViewModel { get; set; }
        public ShowXml(ImportFormViewModel mainViewModel)
        {
            MainViewModel = mainViewModel;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            //var mainViewModel = parameter as MainViewModel;
            //if (mainViewModel != null)
            //{
                if (!MainViewModel.IsVisibleOriginal)
                {
                    MainViewModel.IsVisibleOriginal = true;
                    MainViewModel.IsVisibleForm = false;
                }
                else
                {
                    MainViewModel.IsVisibleOriginal = false;
                    MainViewModel.IsVisibleForm = true;
                }

           // }
        }

        public event EventHandler CanExecuteChanged;
    }
}
