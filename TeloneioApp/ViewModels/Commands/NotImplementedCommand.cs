using System;
using System.Windows.Input;

namespace TeloneioApp.ViewModels.Commands
{
    public class NotImplementedCommand : ICommand
    {
        public bool CanExecute(object parameter)
        {
            throw new NotImplementedException();
        }

        public void Execute(object parameter)
        {
            throw new NotImplementedException();
        }

        public event EventHandler CanExecuteChanged;
    }
}
