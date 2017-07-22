using System;
using System.IO;
using System.Linq;
using System.Windows.Input;
using Microsoft.Win32;

namespace TeloneioApp.ViewModels.Commands
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
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.InitialDirectory = MainSettings.ImportFormXmlPath;
            saveFileDialog.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*";
            if (saveFileDialog.ShowDialog() == true)
            {
                var firstOrDefault = MainViewModel.FirstOrDefault();
                if (firstOrDefault != null)
                {
                    firstOrDefault.RefreshXmlString();
                    File.WriteAllText(saveFileDialog.FileName, firstOrDefault.XmlStringBuilder);
                    //File.Copy(Applicationpath.Replace("\\bin\\Debug", "") + @"\Examples\ED000988.xml", @"" + GetUserAppDataPath() + @"\Examples\ED000988.xml");
                }
            }
        }

        public event EventHandler CanExecuteChanged;
    }
}
