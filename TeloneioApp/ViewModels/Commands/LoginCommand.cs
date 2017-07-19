using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TeloneioApp.ViewModels.Commands
{
    class LoginCommand : ICommand
    {
        public LoginViewModel MainViewModel { get; set; }

        public LoginCommand(LoginViewModel mainViewModel)
        {
            MainViewModel = mainViewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            
        }
    }
}
