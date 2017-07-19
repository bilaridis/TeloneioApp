using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MahApps.Metro.Controls;
using DomainModel.HttpClients;

namespace TeloneioApp.Views
{
    /// <summary>
    /// Interaction logic for StartScreen.xaml
    /// </summary>
    public partial class StartScreen : MetroWindow
    {
        public StartScreen()
        {
            InitializeComponent();
            MainSettings.InitializeStaticData();
            MainSettings.CreateAppDataFiles();
            NavigationFrame.NavigationService.Navigate(new Login());
        }

        private void CutomersPage_Click(object sender, RoutedEventArgs e)
        {
            NavigationFrame.NavigationService.Navigate(new Customers());
        }

        private void ImportFormPage_Click(object sender, RoutedEventArgs e)
        {
            NavigationFrame.NavigationService.Navigate(new ImportForm());
        }
        private void HomeWindow_Click(object sender, RoutedEventArgs e)
        {
            NavigationFrame.NavigationService.Navigate(new Home());
        }

        private void MenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            NavigationFrame.NavigationService.Navigate(new TariffChapter());
        }
    }
}
