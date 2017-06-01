using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TeloneioApp.ViewModels;

namespace TeloneioApp.Models.Commands
{
    public class SelectFileCommand : ICommand
    {
        public ImportFormViewModel MainViewModel { get; set; }
        public SelectFileCommand(ImportFormViewModel mainViewModel)
        {
            MainViewModel = mainViewModel;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var fileInfoEde = parameter as FileInfoEDE;
            if (fileInfoEde != null)
            {
                MainViewModel.SelectFile(fileInfoEde);
            }
        }

        public event EventHandler CanExecuteChanged;
    }
}
