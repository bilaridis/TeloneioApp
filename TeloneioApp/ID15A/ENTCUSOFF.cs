using System.Xml.Serialization;

namespace TeloneioApp.ID15A
{
    public class ENTCUSOFF
    {
        [XmlElement("EnCusOffRefNum01")]
        public string EnCusOffRefNum01 { get; set; }
    }
}