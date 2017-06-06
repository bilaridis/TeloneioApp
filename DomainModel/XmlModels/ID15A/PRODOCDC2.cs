using System.Xml.Serialization;

namespace DomainModel.XmlModels.ID15A
{
    public class PRODOCDC2
    {
        [XmlElement("DocTypDC21")]
        public string DocTypDC21 { get; set; }
        [XmlElement("DocRefDC23")]
        public string DocRefDC23 { get; set; }
        [XmlElement("DocRefDCLNG")]
        public string DocRefDCLNG { get; set; }

    }
}