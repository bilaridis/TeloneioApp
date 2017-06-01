using System.Xml.Serialization;

namespace TeloneioApp.ID15A
{
    public class TRAREP
    {
        [XmlElement("NamTRE1")]
        public string NamTRE1 { get; set; }
        [XmlElement("CouCodTRE1")]
        public string CouCodTRE1 { get; set; }
        [XmlElement("TRAREPLNG")]
        public string TRAREPLNG { get; set; }
        [XmlElement("TINTRE1")]
        public string TINTRE1 { get; set; }
    }
}