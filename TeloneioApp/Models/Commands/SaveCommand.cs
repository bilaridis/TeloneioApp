using System;
using System.IO;
using System.Linq;
using System.Windows.Input;
using Microsoft.Win32;
using TeloneioApp.ViewModels;

namespace TeloneioApp.Models.Commands
{
    public class SaveCommand : ICommand
    {
        public ImportFormViewModel MainViewModel { get; set; }
        public SaveCommand(ImportFormViewModel mainViewModel)
        {
            MainViewModel = mainViewModel;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*";
            if (saveFileDialog.ShowDialog() == true)
            {
                var firstOrDefault = MainViewModel.FirstOrDefault();
                if (firstOrDefault != null)
                    File.WriteAllText(saveFileDialog.FileName, firstOrDefault.XmlStringBuilder);
            }
        }

        public event EventHandler CanExecuteChanged;
    }
}
