using System;
using System.Windows.Input;

namespace TeloneioApp.ViewModels.Commands
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
