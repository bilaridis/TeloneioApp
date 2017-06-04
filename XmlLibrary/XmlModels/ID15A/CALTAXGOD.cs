using System.Xml.Serialization;

namespace XmlLibrary.XmlModels.ID15A
{
    public class CALTAXGOD
    {
        [XmlElement("TypOfTaxCTX1")]
        public string TypOfTaxCTX1 { get; set; }
        [XmlElement("TaxBasCTX1")]
        public decimal TaxBasCTX1 { get; set; }
        [XmlElement("RatOfTaxCTX1")]
        public decimal RatOfTaxCTX1 { get; set; }
        [XmlElement("AmoOfTaxTCL1")]
        public decimal AmoOfTaxTCL1 { get; set; }
        [XmlElement("MetOfPayCTX1")]
        public string MetOfPayCTX1 { get; set; }
    }
}