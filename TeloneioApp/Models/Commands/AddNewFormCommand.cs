using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TeloneioApp.ViewModels;

namespace TeloneioApp.Models.Commands
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
