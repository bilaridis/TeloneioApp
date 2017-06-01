using System.Xml.Serialization;

namespace TeloneioApp.Models.ID15A
{
    public class HEAHEA
    {
        [XmlElement("RefNumHEA4")]
        public string RefNumHEA4 { get; set; }
        [XmlElement("TypOfDecHEA24")]
        public string TypOfDecHEA24 { get; set; }
        [XmlElement("CouOfDesCodHEA30")]
        public string CouOfDesCodHEA30 { get; set; }
        [XmlElement("AgrLocOfGooCodHEA38")]
        public string AgrLocOfGooCodHEA38 { get; set; }
        [XmlElement("AgrLocOfGooHEA39")]
        public string AgrLocOfGooHEA39 { get; set; }
        [XmlElement("AgrLocOfGooHEA39LNG")]
        public string AgrLocOfGooHEA39LNG { get; set; }
        [XmlElement("CouOfDisCodHEA55")]
        public string CouOfDisCodHEA55 { get; set; }
        [XmlElement("TraModAtBorHEA76")]
        public decimal TraModAtBorHEA76 { get; set; }
        [XmlElement("IdeOfMeaOfTraCroHEA85")]
        public string IdeOfMeaOfTraCroHEA85 { get; set; }
        [XmlElement("IdeOfMeaOfTraCroHEA85LNG")]
        public string IdeOfMeaOfTraCroHEA85LNG { get; set; }
        [XmlElement("NatOfMeaOfTraCroHEA87")]
        public string NatOfMeaOfTraCroHEA87 { get; set; }
        [XmlElement("ConIndHEA96")]
        public decimal ConIndHEA96 { get; set; }
        [XmlElement("TotNumOfIteHEA305")]
        public decimal TotNumOfIteHEA305 { get; set; }
        [XmlElement("TotNumOfPacHEA306")]
        public decimal TotNumOfPacHEA306 { get; set; }
        [XmlElement("TotGroMasHEA307")]
        public decimal TotGroMasHEA307 { get; set; }
        [XmlElement("DecDatHEA383")]
        public decimal DecDatHEA383 { get; set; }
        [XmlElement("DecPlaHEA394")]
        public string DecPlaHEA394 { get; set; }
        [XmlElement("DecPlaHEA394LNG")]
        public string DecPlaHEA394LNG { get; set; }
        [XmlElement("TypOfDecBx12HEA651")]
        public string TypOfDecBx12HEA651 { get; set; }
        [XmlElement("FinBanInfHEA1027")]
        public string FinBanInfHEA1027 { get; set; }
        [XmlElement("IdeMeaTraArr4004")]
        public string IdeMeaTraArr4004 { get; set; }
        [XmlElement("IdeMeaTraArr4005LNG")]
        public string IdeMeaTraArr4005LNG { get; set; }
        [XmlElement("NatOfMeaOfTraAtArrHEA54")]
        public string NatOfMeaOfTraAtArrHEA54 { get; set; }
        [XmlElement("MetOfPayHEA590")]
        public string MetOfPayHEA590 { get; set; }

    }
}