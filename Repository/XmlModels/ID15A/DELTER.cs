using System.Xml.Serialization;

namespace DomainModel.XmlModels.ID15A
{
    public class DELTER
    {
        [XmlElement("IncCodTDL1")]
        public string IncCodTDL1 { get; set; }
        [XmlElement("ComCodTDL1")]
        public string ComCodTDL1 { get; set; }
        [XmlElement("ComInfDELTER387")]
        public string ComInfDELTER387 { get; set; }
        [XmlElement("ComInfDELTER387LNG")]
        public string ComInfDELTER387LNG { get; set; }
    }
}