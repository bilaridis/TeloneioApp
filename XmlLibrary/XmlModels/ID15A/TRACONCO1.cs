using System.Xml.Serialization;

namespace XmlLibrary.XmlModels.ID15A
{
    public class TRACONCO1
    {

        [XmlElement("NamCO17")]
        public string NamCO17 { get; set; }
        [XmlElement("StrAndNumCO122")]
        public string StrAndNumCO122 { get; set; }
        [XmlElement("PosCodCO123")]
        public string PosCodCO123 { get; set; }
        [XmlElement("CitCO124")]
        public string CitCO124 { get; set; }
        [XmlElement("CouCO125")]
        public string CouCO125 { get; set; }
        [XmlElement("NADLNGCO")]
        public string NADLNGCO { get; set; }
    }
}