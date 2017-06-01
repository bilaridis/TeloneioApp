using System.IO;
using System.Text;

namespace TeloneioApp.StaticResources
{
    public class MyStringWriter : StringWriter
    {
        public MyStringWriter() : base()
        {

        }
        public override Encoding Encoding => Encoding.UTF8;
    }
}