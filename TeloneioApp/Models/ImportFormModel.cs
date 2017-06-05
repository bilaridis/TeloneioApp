using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using TeloneioApp.Annotations;
using TeloneioApp.Extensions;
using XmlLibrary.XmlModels.ID15A;
using TeloneioApp.StaticResources;

namespace TeloneioApp.Models
{
    public class ImportFormModel : INotifyPropertyChanged
    {
        private string _xmlStringBuilder;

        public ImportFormModel()
        {
            //ID15A.ID15A obj = XmlExtension.XmlReaderForID15A("C:\\Users\\billi\\Documents\\Visual Studio 2017\\Projects\\TeloneioApp\\TeloneioApp\\Examples\\ED000992.xml");

            //XmlObjectId15A = obj;
        }
        public ImportFormModel(ID15A modelId15A)
        {
            XmlObjectId15A = modelId15A;
            XmlStringBuilder = XmlExtension.PrintXML(XmlExtension.Serialize(XmlObjectId15A));
        }
        public ID15A XmlObjectId15A { get; set; }

        public string XmlStringBuilder
        {
            get => _xmlStringBuilder;
            set
            {
                _xmlStringBuilder = value;
                OnPropertyChanged("XmlStringBuilder");
            }
        }
        public void RefreshXmlString()
        {
            XmlStringBuilder = XmlExtension.PrintXML(XmlExtension.Serialize(XmlObjectId15A));
        }

        public string MesSenMES3
        {
            get { return XmlObjectId15A.MesSenMES3; }
            set
            {
                XmlObjectId15A.MesSenMES3 = value;
                RefreshXmlString();
            }
        }

        public int MesRecMES6
        {
            get { return XmlObjectId15A.MesRecMES6; }
            set
            {
                XmlObjectId15A.MesRecMES6 = value;
                RefreshXmlString();
            }
        }

        public int DatOfPreMES9
        {
            get { return XmlObjectId15A.DatOfPreMES9; }
            set
            {
                XmlObjectId15A.DatOfPreMES9 = value;
                RefreshXmlString();
            }
        }

        public int TimOfPreMES10
        {
            get { return XmlObjectId15A.TimOfPreMES10; }
            set
            {
                XmlObjectId15A.TimOfPreMES10 = value;
                RefreshXmlString();
            }
        }

        public int TesIndMES18
        {
            get { return XmlObjectId15A.TesIndMES18; }
            set
            {
                XmlObjectId15A.TesIndMES18 = value;
                RefreshXmlString();
            }
        }

        public long MesIdeMES19
        {
            get { return XmlObjectId15A.MesIdeMES19; }
            set
            {
                XmlObjectId15A.MesIdeMES19 = value;
                RefreshXmlString();
            }
        }

        public string MesTypMES20
        {
            get { return XmlObjectId15A.MesTypMES20; }
            set
            {
                XmlObjectId15A.MesTypMES20 = value;
                RefreshXmlString();
            }
        }

        public HEAHEA HEAHEA
        {
            get { return XmlObjectId15A.HEAHEA; }
            set
            {
                XmlObjectId15A.HEAHEA = value;
                RefreshXmlString();
            }
        }

        public TRACONCO1 TRACONCO1
        {
            get { return XmlObjectId15A.TRACONCO1; }
            set
            {
                XmlObjectId15A.TRACONCO1 = value;
                RefreshXmlString();
            }
        }

        public TRACONCE1 TRACONCE1
        {
            get { return XmlObjectId15A.TRACONCE1; }
            set
            {
                XmlObjectId15A.TRACONCE1 = value;
                RefreshXmlString();
            }
        }

        public List<GOOITEGDS> GOOITEGDS
        {
            get { return XmlObjectId15A.GOOITEGDS; }
            set
            {
                XmlObjectId15A.GOOITEGDS = value;
                RefreshXmlString();
            }
        }

        public DELTER DELTER
        {
            get { return XmlObjectId15A.DELTER; }
            set
            {
                XmlObjectId15A.DELTER = value;
                RefreshXmlString();
            }
        }

        public TRADAT TRADAT
        {
            get { return XmlObjectId15A.TRADAT; }
            set
            {
                XmlObjectId15A.TRADAT = value;
                RefreshXmlString();
            }
        }

        public TRAREP TRAREP
        {
            get { return XmlObjectId15A.TRAREP; }
            set
            {
                XmlObjectId15A.TRAREP = value;
                RefreshXmlString();
            }
        }

        public STATREP385 STATREP385
        {
            get { return XmlObjectId15A.STATREP385; }
            set
            {
                XmlObjectId15A.STATREP385 = value;
                RefreshXmlString();
            }
        }

        public ENTCUSOFF ENTCUSOFF
        {
            get { return XmlObjectId15A.ENTCUSOFF; }
            set
            {
                XmlObjectId15A.ENTCUSOFF = value;
                RefreshXmlString();
            }
        }

        public IMPCUSOFF IMPCUSOFF
        {
            get { return XmlObjectId15A.IMPCUSOFF; }
            set
            {
                XmlObjectId15A.IMPCUSOFF = value;
                RefreshXmlString();
            }
        }



        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
