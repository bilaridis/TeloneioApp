using System;
using System.IO;
using System.Linq;
using System.Windows.Input;
using Microsoft.Win32;
using DomainModel;
using TeloneioApp.Views;
using System.Collections.ObjectModel;
using DomainModel.Models;

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

        //private Customer customer;
        public void Execute(object parameter)
        {

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.InitialDirectory = MainSettings.ImportFormXmlPath;
            //customer = new Customer();

            

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

                using (var model = new LocalModel())
                {
                    model.LoginCustomerExtensions.FirstOrDefault(x => x.CustomerID == MainSettings.CustomerDetails.Id).LRNCounter = MainSettings.CustomerExtension.LRNCounter + 1;
                    model.LoginCustomerExtensions.FirstOrDefault(x => x.CustomerID == MainSettings.CustomerDetails.Id).MessageCounter = MainSettings.CustomerExtension.MessageCounter + 1;
                    MainSettings.CustomerExtension = model.LoginCustomerExtensions.FirstOrDefault(x => x.Id == 1);
                }
            }
        }

        public event EventHandler CanExecuteChanged;
    }
}
