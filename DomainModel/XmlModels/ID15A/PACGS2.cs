﻿using System.Xml.Serialization;

namespace DomainModel.XmlModels.ID15A
{
    public class PACGS2
    {
        [XmlElement("MarNumOfPacGS21")]
        public string MarNumOfPacGS21 { get; set; }
        [XmlElement("MarNumOfPacGS21LNG")]
        public string MarNumOfPacGS21LNG { get; set; }
        [XmlElement("KinOfPacGS23")]
        public string KinOfPacGS23 { get; set; }
        [XmlElement("NumOfPacGS24")]
        public string NumOfPacGS24 { get; set; }

    }
}