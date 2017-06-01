using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TeloneioApp.ViewModels;

namespace TeloneioApp.Models.Commands
{
    public class OpenImportForm : ICommand
    {
        public ViewModelBaseClass StartScreenViewModel { get; set; }
        public OpenImportForm(ViewModelBaseClass startScreenViewModel)
        {
            StartScreenViewModel = startScreenViewModel;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            StartScreenViewModel.ProcessNavRequest(new ImportForm());
        }

        public event EventHandler CanExecuteChanged;
    }
}
