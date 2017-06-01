using System.Xml.Serialization;

namespace TeloneioApp.ID15A
{
    public class COMCODGODITM
    {
        [XmlElement("ComNomCMD1")]
        public long ComNomCMD1 { get; set; }
        [XmlElement("TARCodCMD1")]
        public int TARCodCMD1 { get; set; }
        [XmlElement("TARFirAddCodCMD1")]
        public int TARFirAddCodCMD1 { get; set; }
        [XmlElement("TARSecAddCodCMD1")]
        public int TARSecAddCodCMD1 { get; set; }
        [XmlElement("NAtAddCodCMD1")]
        public int NAtAddCodCMD1 { get; set; }
    }
}