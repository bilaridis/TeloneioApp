using System;
using System.Windows.Input;
using Microsoft.Win32;
using TeloneioApp.Models;

namespace TeloneioApp.ViewModels.Commands
{
    public class ImportCommand : ICommand
    {
        public ImportFormViewModel MainViewModel { get; set; }
        public ImportCommand(ImportFormViewModel mainViewModel)
        {
            MainViewModel = mainViewModel;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = true;
            openFileDialog.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (openFileDialog.ShowDialog() == true)
            {
                for (int i = 0; i < openFileDialog.SafeFileNames.Length; i++)
                {
                    string fullPath = openFileDialog.FileNames[i];
                    string fileName = openFileDialog.SafeFileNames[i];
                    string path = fullPath.Replace(fileName, "");
                    var fclass = new FileInfoEDE
                    {
                        Name = fileName,
                        length = 0,
                        DirectoryName = path,
                        FullName = fullPath,
                        Extension = fileName.Split('.')[1]
                    };
                    MainViewModel.Files.Add(fclass);
                }
            }
        }

        public event EventHandler CanExecuteChanged;
    }
}
