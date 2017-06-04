using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using TeloneioApp.Annotations;
using TeloneioApp.Models.ID15A;
using TeloneioApp.StaticResources;

namespace TeloneioApp.Models
{
    public class ImportFormModel : INotifyPropertyChanged
    {
        private string _xmlStringBuilder;

        public ImportFormModel()
        {
            //ID15A.ID15A obj = XmlExtension.XmlReaderForID15A("C:\\Users\\billi\\Documents\\Visual Studio 2017\\Projects\\TeloneioApp\\TeloneioApp\\Examples\\ED000992.xml");

            //BindableModelId15A = obj;
        }
        public ImportFormModel(XmlLibrary.XmlModels.ID15A.ID15A modelId15A)
        {
            XmlObjectId15A = modelId15A;
            XmlStringBuilder = XmlExtension.PrintXML(XmlExtension.Serialize(BindableModelId15A));
        }

        public void RefreshXmlString()
        {
            XmlStringBuilder = XmlExtension.PrintXML(XmlExtension.Serialize(BindableModelId15A));
        }
        //TODO : MakeConvert TO Bindable Model

        private XmlLibrary.XmlModels.ID15A.ID15A XmlObjectId15A { get; set; }

        private ImportFormModel BindableModelId15A { get; set; }

        public string XmlStringBuilder
        {
            get { return _xmlStringBuilder; }
            set
            {
                _xmlStringBuilder = value; 
                OnPropertyChanged("XmlStringBuilder");
            }
        }

        public string MesSenMES3
        {
            get { return BindableModelId15A.MesSenMES3; }
            set
            {
                BindableModelId15A.MesSenMES3 = value;
                RefreshXmlString();
            }
        }

        public int MesRecMES6
        {
            get { return BindableModelId15A.MesRecMES6; }
            set
            {
                BindableModelId15A.MesRecMES6 = value;
                RefreshXmlString();
            }
        }

        public int DatOfPreMES9
        {
            get { return BindableModelId15A.DatOfPreMES9; }
            set { BindableModelId15A.DatOfPreMES9 = value; RefreshXmlString(); }
        }

        public int TimOfPreMES10
        {
            get { return BindableModelId15A.TimOfPreMES10; }
            set { BindableModelId15A.TimOfPreMES10 = value; RefreshXmlString(); }
        }

        public int TesIndMES18
        {
            get { return BindableModelId15A.TesIndMES18; }
            set { BindableModelId15A.TesIndMES18 = value; RefreshXmlString(); }
        }

        public long MesIdeMES19
        {
            get { return BindableModelId15A.MesIdeMES19; }
            set { BindableModelId15A.MesIdeMES19 = value; RefreshXmlString(); }
        }

        public string MesTypMES20
        {
            get { return BindableModelId15A.MesTypMES20; }
            set { BindableModelId15A.MesTypMES20 = value; RefreshXmlString(); }
        }

        public HEAHEA Head
        {
            get { return BindableModelId15A.Head; }
            set { BindableModelId15A.Head = value; RefreshXmlString(); }
        }

        public TRACONCO1 TRACONCO1
        {
            get { return BindableModelId15A.TRACONCO1; }
            set { BindableModelId15A.TRACONCO1 = value; RefreshXmlString(); }
        }

        public TRACONCE1 TRACONCE1
        {
            get { return BindableModelId15A.TRACONCE1; }
            set { BindableModelId15A.TRACONCE1 = value; RefreshXmlString(); }
        }

        public List<GOOITEGDS> GOOITEGDS
        {
            get { return BindableModelId15A.GOOITEGDS; }
            set { BindableModelId15A.GOOITEGDS = value; RefreshXmlString(); }
        }

        public DELTER DELTER
        {
            get { return BindableModelId15A.DELTER; }
            set { BindableModelId15A.DELTER = value; RefreshXmlString(); }
        }

        public TRADAT TRADAT
        {
            get { return BindableModelId15A.TRADAT; }
            set { BindableModelId15A.TRADAT = value; RefreshXmlString(); }
        }

        public TRAREP TRAREP
        {
            get { return BindableModelId15A.TRAREP; }
            set { BindableModelId15A.TRAREP = value; RefreshXmlString(); }
        }

        public STATREP385 STATREP385
        {
            get { return BindableModelId15A.STATREP385; }
            set { BindableModelId15A.STATREP385 = value; RefreshXmlString(); }
        }

        public ENTCUSOFF ENTCUSOFF
        {
            get { return BindableModelId15A.ENTCUSOFF; }
            set { BindableModelId15A.ENTCUSOFF = value; RefreshXmlString(); }
        }

        public IMPCUSOFF IMPCUSOFF
        {
            get { return BindableModelId15A.IMPCUSOFF; }
            set { BindableModelId15A.IMPCUSOFF = value; RefreshXmlString(); }
        }



        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
