using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TeloneioApp.ViewModels;
using TeloneioApp.Views;

namespace TeloneioApp.Models.Commands
{
    public class OpenCustomersCommand : ICommand
    {
        public ViewModelBaseClass StartScreenViewModel { get; set; }
        public OpenCustomersCommand(ViewModelBaseClass startScreenViewModel)
        {
            StartScreenViewModel = startScreenViewModel;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            StartScreenViewModel.ProcessNavRequest(new MainWindow());
        }

        public event EventHandler CanExecuteChanged;
    }
}
