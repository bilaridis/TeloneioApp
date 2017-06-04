using System.Xml.Serialization;

namespace XmlLibrary.XmlModels.ID15A
{
    public class TRACONCE1
    {
        [XmlElement("NamCE17")]
        public string NamCE17 { get; set; }
        [XmlElement("StrAndNumCE122")]
        public string StrAndNumCE122 { get; set; }

        [XmlElement("PosCodCE123")]
        public string PosCodCE123 { get; set; }
        [XmlElement("CitCE124")]
        public string CitCE124 { get; set; }
        [XmlElement("CouCE125")]
        public string CouCE125 { get; set; }
        [XmlElement("NADLNGCE")]
        public string NADLNGCE { get; set; }
        [XmlElement("TINCE159")]
        public string TINCE159 { get; set; }
    }
}