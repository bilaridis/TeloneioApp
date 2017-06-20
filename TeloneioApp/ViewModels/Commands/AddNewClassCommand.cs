using System;
using System.Windows.Input;

namespace TeloneioApp.ViewModels.Commands
{
    public class AddNewClassCommand : ICommand
    {
        public ImportFormViewModel ImportFormViewModel { get; set; }

        public AddNewClassCommand(ImportFormViewModel importFormViewModel)
        {
            ImportFormViewModel = importFormViewModel;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            ImportFormViewModel.AddNewClass();
        }

        public event EventHandler CanExecuteChanged;
    }
}
