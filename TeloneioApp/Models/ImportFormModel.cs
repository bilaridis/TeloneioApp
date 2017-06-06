using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Configuration;
using System.Runtime.CompilerServices;
using System.Windows.Data;
using DomainModel.XmlModels.ID15A;
using TeloneioApp.Annotations;
using TeloneioApp.Extensions;
using TeloneioApp.StaticResources;

namespace TeloneioApp.Models
{
    public class ImportFormModel : INotifyPropertyChanged
    {
        private string _xmlStringBuilder;

        public ImportFormModel()
        {
            XmlObjectId15A = new ID15A();
            _gooitegdss = new ObservableCollection<GOOITEGDS>();
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

        public ImportFormModel(ID15A modelId15A)
        {
            XmlObjectId15A = modelId15A;
            XmlStringBuilder = XmlExtension.PrintXML(XmlObjectId15A.Serialize());
            _gooitegdss = XmlObjectId15A.GOOITEGDS.ToObservableCollection();
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

        public string MesSenMES3
        {
            get => XmlObjectId15A.MesSenMES3;
            set
            {
                XmlObjectId15A.MesSenMES3 = value;
                OnPropertyChanged("MesSenMES3");
                RefreshXmlString();
            }
        }

        public int MesRecMES6
        {
            get => XmlObjectId15A.MesRecMES6;
            set
            {
                XmlObjectId15A.MesRecMES6 = value;
                OnPropertyChanged("MesRecMES6");
                RefreshXmlString();
            }
        }

        public int DatOfPreMES9
        {
            get => XmlObjectId15A.DatOfPreMES9;
            set
            {
                XmlObjectId15A.DatOfPreMES9 = value;
                OnPropertyChanged("DatOfPreMES9");
                RefreshXmlString();
            }
        }

        public int TimOfPreMES10
        {
            get => XmlObjectId15A.TimOfPreMES10;
            set
            {
                XmlObjectId15A.TimOfPreMES10 = value;
                OnPropertyChanged("TimOfPreMES10");
                RefreshXmlString();
            }
        }

        public int TesIndMES18
        {
            get => XmlObjectId15A.TesIndMES18;
            set
            {
                XmlObjectId15A.TesIndMES18 = value;
                OnPropertyChanged("TesIndMES18");
                RefreshXmlString();
            }
        }

        public long MesIdeMES19
        {
            get => XmlObjectId15A.MesIdeMES19;
            set
            {
                XmlObjectId15A.MesIdeMES19 = value;
                OnPropertyChanged("MesIdeMES19");
                RefreshXmlString();
            }
        }

        public string MesTypMES20
        {
            get => XmlObjectId15A.MesTypMES20;
            set
            {
                XmlObjectId15A.MesTypMES20 = value;
                OnPropertyChanged("MesTypMES20");
                RefreshXmlString();
            }
        }

        public HEAHEA HEAHEA
        {
            get => XmlObjectId15A.HEAHEA;
            set
            {
                XmlObjectId15A.HEAHEA = value;
                OnPropertyChanged("HEAHEA");
                RefreshXmlString();
            }
        }

        public TRACONCO1 TRACONCO1
        {
            get => XmlObjectId15A.TRACONCO1;
            set
            {
                XmlObjectId15A.TRACONCO1 = value;
                OnPropertyChanged("TRACONCO1");
                RefreshXmlString();
            }
        }

        public TRACONCE1 TRACONCE1
        {
            get => XmlObjectId15A.TRACONCE1;
            set
            {
                XmlObjectId15A.TRACONCE1 = value;
                OnPropertyChanged("TRACONCE1");
                RefreshXmlString();
            }
        }

        public void AddToGoods(GOOITEGDS item)
        {
            _gooitegdss.Add(item);
        }

        private ObservableCollection<GOOITEGDS> _gooitegdss;

        public ObservableCollection<GOOITEGDS> GOOITEGDS
        {
            get
            {
               // _gooitegdss = XmlObjectId15A.GOOITEGDS.ToObservableCollection();
                return _gooitegdss;
            }
           
            //set
            //{
            //    _gooitegdss = value;
            //    XmlObjectId15A.GOOITEGDS = new List<GOOITEGDS>((IEnumerable<GOOITEGDS>) value.GetEnumerator());
            //    OnPropertyChanged("GOOITEGDS");
            //    RefreshXmlString();
            //}
        }

        public DELTER DELTER
        {
            get => XmlObjectId15A.DELTER;
            set
            {
                XmlObjectId15A.DELTER = value;
                OnPropertyChanged("DELTER");
                RefreshXmlString();
            }
        }

        public TRADAT TRADAT
        {
            get => XmlObjectId15A.TRADAT;
            set
            {
                XmlObjectId15A.TRADAT = value;
                OnPropertyChanged("TRADAT");
                RefreshXmlString();
            }
        }

        public TRAREP TRAREP
        {
            get => XmlObjectId15A.TRAREP;
            set
            {
                XmlObjectId15A.TRAREP = value;
                OnPropertyChanged("TRAREP");
                RefreshXmlString();
            }
        }

        public STATREP385 STATREP385
        {
            get => XmlObjectId15A.STATREP385;
            set
            {
                XmlObjectId15A.STATREP385 = value;
                OnPropertyChanged("STATREP385");
                RefreshXmlString();
            }
        }

        public ENTCUSOFF ENTCUSOFF
        {
            get => XmlObjectId15A.ENTCUSOFF;
            set
            {
                XmlObjectId15A.ENTCUSOFF = value;
                OnPropertyChanged("ENTCUSOFF");
                RefreshXmlString();
            }
        }

        public IMPCUSOFF IMPCUSOFF
        {
            get => XmlObjectId15A.IMPCUSOFF;
            set
            {
                XmlObjectId15A.IMPCUSOFF = value;
                OnPropertyChanged("IMPCUSOFF");
                RefreshXmlString();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void RefreshXmlString()
        {
            XmlStringBuilder = XmlExtension.PrintXML(XmlObjectId15A.Serialize());
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}