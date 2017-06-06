using System.Xml.Serialization;

namespace DomainModel.XmlModels.ID15A
{
    public class TAXADDELE100
    {
        [XmlElement("SupUniCodTAXADDELE101")]
        public string SupUniCodTAXADDELE101 { get; set; }
        [XmlElement("AmoOfSupUniTAXADDELE100")]
        public string AmoOfSupUniTAXADDELE100 { get; set; }
    }
}