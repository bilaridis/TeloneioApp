﻿using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace XmlLibrary.XmlModels.ID15A
{
    [Serializable]
    [XmlRoot(DataType = null, ElementName = "ID15A", IsNullable = true, Namespace = null)]
    public class ID15A
    {
        public ID15A()
        {
            GOOITEGDS = new List<GOOITEGDS>();
            HEAHEA = new HEAHEA();
            TRACONCE1 = new TRACONCE1();
            TRACONCO1 = new TRACONCO1();
            DELTER = new DELTER();
            TRADAT = new TRADAT();
            TRAREP = new TRAREP();
            STATREP385 = new STATREP385();
            ENTCUSOFF = new ENTCUSOFF();
            IMPCUSOFF = new IMPCUSOFF();
        }


        [XmlElement("MesSenMES3")]
        public string MesSenMES3 { get; set; }

        [XmlElement("MesRecMES6")]
        public int MesRecMES6 { get; set; }

        [XmlElement("DatOfPreMES9")]
        public int DatOfPreMES9 { get; set; }

        [XmlElement("TimOfPreMES10")]
        public int TimOfPreMES10 { get; set; }

        [XmlElement("TesIndMES18")]
        public int TesIndMES18 { get; set; }

        [XmlElement("MesIdeMES19")]
        public long MesIdeMES19 { get; set; }

        [XmlElement("MesTypMES20")]
        public string MesTypMES20 { get; set; }

        [XmlElement("HEAHEA")]
        public HEAHEA HEAHEA { get; set; }

        [XmlElement("TRACONCO1")]
        public TRACONCO1 TRACONCO1 { get; set; }

        [XmlElement("TRACONCE1")]
        public TRACONCE1 TRACONCE1 { get; set; }

        [XmlElement("GOOITEGDS")]
        public List<GOOITEGDS> GOOITEGDS { get; set; }

        [XmlElement("DELTER")]
        public DELTER DELTER { get; set; }

        [XmlElement("TRADAT")]
        public TRADAT TRADAT { get; set; }

        [XmlElement("TRAREP")]
        public TRAREP TRAREP { get; set; }

        [XmlElement("STATREP385")]
        public STATREP385 STATREP385 { get; set; }

        [XmlElement("ENTCUSOFF")]
        public ENTCUSOFF ENTCUSOFF { get; set; }

        [XmlElement("IMPCUSOFF")]
        public IMPCUSOFF IMPCUSOFF { get; set; }
    }
}
