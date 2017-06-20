using System;
using System.Windows.Input;

namespace TeloneioApp.ViewModels.Commands
{
    public class AddNewFormCommand : ICommand
    {
        public ImportFormViewModel ImportFormViewModel { get; set; }

        public AddNewFormCommand(ImportFormViewModel importFormViewModel)
        {
            ImportFormViewModel = importFormViewModel;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            ImportFormViewModel.AddNewForm();
        }

        public event EventHandler CanExecuteChanged;
    }
}
