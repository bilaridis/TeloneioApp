using System.Windows.Controls;
using System.Windows.Input;

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

        private void UIElement_OnPreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            ScrollViewer scv = (ScrollViewer)sender;
            scv.ScrollToVerticalOffset(scv.VerticalOffset - e.Delta);
            e.Handled = true;
        }
    }
}
