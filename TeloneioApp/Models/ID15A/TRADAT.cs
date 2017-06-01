﻿using System.Xml.Serialization;

namespace TeloneioApp.Models.ID15A
{
    public class TRADAT
    {
        [XmlElement("CurTRD1")]
        public string CurTRD1 { get; set; }
        [XmlElement("TotAmoInvTRD1")]
        public decimal TotAmoInvTRD1 { get; set; }
        [XmlElement("ExcRatTRD1")]
        public decimal ExcRatTRD1 { get; set; }
    }
}