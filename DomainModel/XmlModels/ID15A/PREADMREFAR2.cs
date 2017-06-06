using System.Xml.Serialization;

namespace DomainModel.XmlModels.ID15A
{
    public class PREADMREFAR2
    {

        [XmlElement("PreDocTypAR21")]
        public string PreDocTypAR21 { get; set; }
        [XmlElement("PreDocRefAR26")]
        public string PreDocRefAR26 { get; set; }
        [XmlElement("PreDocRefLNG")]
        public string PreDocRefLNG { get; set; }
        [XmlElement("PreDocCatPREADMREF21")]
        public string PreDocCatPREADMREF21 { get; set; }
    }
}