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
using System.Windows.Navigation;
using System.Windows.Shapes;
using TeloneioApp.Models;
using TeloneioApp.Models.ID15A;
using TeloneioApp.StaticResources;

namespace TeloneioApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class ImportForm : Page
    {
        public ImportForm()
        {
            InitializeComponent();
           
            //try
            //{
            //    int i = 0;
            //    ID15A obj = XmlExtension.XmlReaderForID15A(AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Debug\\", "\\") + "\\Examples\\ED000989.xml");

            //    ParagraphConsole.Inlines.Add(XmlExtension.PrintXML(XmlExtension.Serialize(obj)));
            //    int j = 1;
            //}
            //catch (Exception ex)
            //{

            //    MessageBox.Show($@"{ex}");
            //}
            
            
        }
    }
}
