using System.Xml.Serialization;

namespace TeloneioApp.Models.ID15A
{
    public class IMPCUSOFF
    {
        [XmlElement("RefNumIMPCUSOFF")]
        public string RefNumIMPCUSOFF { get; set; }
    }
}