using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TeloneioApp.ViewModels.Commands
{
    public class RemoveClassCommand : ICommand
    {
        private ImportFormViewModel ImportFormViewModel { get; set; }

        public RemoveClassCommand(ImportFormViewModel importFormViewModel)
        {
            ImportFormViewModel = importFormViewModel;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            ImportFormViewModel.RemoveSelectedClasses();
        }

        public event EventHandler CanExecuteChanged;
    }
}
