using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TeloneioApp.ViewModels;

namespace TeloneioApp.Models.Commands
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
