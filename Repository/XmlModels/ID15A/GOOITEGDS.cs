using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;

namespace DomainModel.XmlModels.ID15A
{
    public class GOOITEGDS : INotifyPropertyChanged
    {
        private decimal _iteNumGds7;
        private string _gooDesGds23;
        private string _gooDesGds23Lng;
        private decimal _groMasGds46;
        private decimal _netMasGds48;
        private decimal _proReqGdi1;
        private decimal _preProGdi1;
        private decimal _comNatProGim1;
        private string _staValCurGdi1;
        private string _couOfOriGdi1;
        private decimal _pre4046;
        private decimal _proPri4002;
        private decimal _estOfValGds14;
        private decimal _staValAmoGdi1;
        private List<PREADMREFAR2> _preadmrefar2;
        private List<PRODOCDC2> _prodocdc2;
        private COMCODGODITM _comcodgoditm;
        private List<CALTAXGOD> _caltaxgod;
        private List<CONNR2> _connr2;
        private PACGS2 _pacgs2;
        private TAXADDELE100 _taxaddele100;
        private string _concatenationOfContainers;
        private const string descrTest = "My descriprtion Test";

        public GOOITEGDS()
        {
            CALTAXGOD = new List<CALTAXGOD>();
            PREADMREFAR2 = new List<PREADMREFAR2>();
            PRODOCDC2 = new List<PRODOCDC2>();
            CONNR2 = new List<CONNR2>();
            COMCODGODITM = new COMCODGODITM();
            PACGS2 = new PACGS2();
            TAXADDELE100 = new TAXADDELE100();

            PACGS2.PropertyChanged += PACGS2_PropertyChanged;
        }

        public GOOITEGDS(int classCounter)
        {
            IteNumGDS7 = classCounter;
            CALTAXGOD = new List<CALTAXGOD>();
            PREADMREFAR2 = new List<PREADMREFAR2>();
            PRODOCDC2 = new List<PRODOCDC2>();
            CONNR2 = new List<CONNR2>();
            COMCODGODITM = new COMCODGODITM();
            PACGS2 = new PACGS2();
            TAXADDELE100 = new TAXADDELE100();

            PACGS2.PropertyChanged += PACGS2_PropertyChanged;

        }


        private void PACGS2_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName.Equals("MarNumOfPacGS21") || e.PropertyName.Equals("KinOfPacGS23") || e.PropertyName.Equals("NumOfPacGS24"))
            {
                var msg1 = PACGS2.MarNumOfPacGS21 ?? "";
                var msg2 = PACGS2.KinOfPacGS23 ?? "";
                var msg3 = PACGS2.NumOfPacGS24.ToString();
                var msg4 = "";
                if (GooDesGDS23 == null) GooDesGDS23 = "";
                GooDesGDS23 = msg2 + " " + msg3 + " " + msg1 + " " + ConcatenationOfContainers + " " + descrTest;
            }
            OnPropertyChanged("Packets");
        }

        [XmlElement("IteNumGDS7")]
        public decimal IteNumGDS7
        {
            get { return _iteNumGds7; }
            set
            {
                _iteNumGds7 = value;
                OnPropertyChanged("IteNumGDS7");
            }
        }


        [XmlElement("GooDesGDS23")]
        public string GooDesGDS23
        {
            get { return _gooDesGds23; }
            set
            {
                _gooDesGds23 = value;
                var stringForCheck = value;
                GooDesGDS23LNG = MainSettings.FoundGreekLetters(stringForCheck) ? "EL" : "EN";
                OnPropertyChanged("GooDesGDS23");
            }
        }


        [XmlElement("GooDesGDS23LNG")]
        public string GooDesGDS23LNG
        {
            get { return _gooDesGds23Lng; }
            set
            {
                _gooDesGds23Lng = value;
                OnPropertyChanged("GooDesGDS23LNG");
            }
        }


        [XmlElement("GroMasGDS46")]
        public decimal GroMasGDS46
        {
            get { return _groMasGds46; }
            set
            {
                _groMasGds46 = value;
                OnPropertyChanged("GroMasGDS46");
            }
        }


        [XmlElement("NetMasGDS48")]
        public decimal NetMasGDS48
        {
            get { return _netMasGds48; }
            set
            {
                _netMasGds48 = value;
                OnPropertyChanged("NetMasGDS48");
            }
        }


        [XmlElement("ProReqGDI1")]
        public decimal ProReqGDI1
        {
            get { return _proReqGdi1; }
            set
            {
                _proReqGdi1 = value;
                OnPropertyChanged("ProReqGDI1");
            }
        }

        [XmlElement("PreProGDI1")]
        public decimal PreProGDI1
        {
            get { return _preProGdi1; }
            set
            {
                _preProGdi1 = value;
                OnPropertyChanged("PreProGDI1");
            }
        }


        [XmlElement("ComNatProGIM1")]
        public decimal ComNatProGIM1
        {
            get { return _comNatProGim1; }
            set
            {
                _comNatProGim1 = value;
                OnPropertyChanged("ComNatProGIM1");
            }
        }


        [XmlElement("StaValCurGDI1")]
        public string StaValCurGDI1
        {
            get { return _staValCurGdi1; }
            set
            {
                _staValCurGdi1 = value;
                OnPropertyChanged("StaValCurGDI1");
            }
        }


        [XmlElement("CouOfOriGDI1")]
        public string CouOfOriGDI1
        {
            get { return _couOfOriGdi1; }
            set
            {
                _couOfOriGdi1 = value;
                OnPropertyChanged("CouOfOriGDI1");
            }
        }


        [XmlElement("Pre4046")]
        public decimal Pre4046
        {
            get { return _pre4046; }
            set
            {
                _pre4046 = value;
                OnPropertyChanged("Pre4046");
            }
        }

        [XmlElement("ProPri4002")]
        public decimal ProPri4002
        {
            get { return _proPri4002; }
            set
            {
                _proPri4002 = value;
                OnPropertyChanged("ProPri4002");
            }
        }


        [XmlElement("EstOfValGDS14")]
        public decimal EstOfValGDS14
        {
            get { return _estOfValGds14; }
            set
            {
                _estOfValGds14 = value;
                OnPropertyChanged("EstOfValGDS14");
            }
        }

        [XmlElement("StaValAmoGDI1")]
        public decimal StaValAmoGDI1
        {
            get { return _staValAmoGdi1; }
            set
            {
                _staValAmoGdi1 = value;
                OnPropertyChanged("StaValAmoGDI1");
            }
        }

        [XmlElement("PREADMREFAR2")]
        public List<PREADMREFAR2> PREADMREFAR2
        {
            get { return _preadmrefar2; }
            set
            {
                _preadmrefar2 = value;
                OnPropertyChanged("PREADMREFAR2");
            }
        }

        [XmlElement("PRODOCDC2")]
        public List<PRODOCDC2> PRODOCDC2
        {
            get { return _prodocdc2; }
            set
            {
                _prodocdc2 = value;
                OnPropertyChanged("PRODOCDC2");
            }
        }

        [XmlElement("COMCODGODITM")]
        public COMCODGODITM COMCODGODITM
        {
            get { return _comcodgoditm; }
            set
            {
                _comcodgoditm = value;
                OnPropertyChanged("COMCODGODITM");
            }
        }

        [XmlElement("CALTAXGOD")]
        public List<CALTAXGOD> CALTAXGOD
        {
            get { return _caltaxgod; }
            set
            {
                _caltaxgod = value;
                OnPropertyChanged("CALTAXGOD");
            }
        }

        public string ConcatenationOfContainers
        {
            get { return _concatenationOfContainers; }
            set
            {
                _concatenationOfContainers = value;

                var msg1 = PACGS2.MarNumOfPacGS21 ?? "";
                var msg2 = PACGS2.KinOfPacGS23 ?? "";
                var msg3 = PACGS2.NumOfPacGS24.ToString();
                var msg4 = "";
                foreach (var item in CONNR2)
                {
                    msg4 += item.ConNumNR21 + ",";
                }
                if (msg4.Length >= 0)
                {
                    GooDesGDS23 = msg2 + " " + msg3 + " " + msg1 + " " + value + " " + descrTest;

                    OnPropertyChanged("Packets");
                }

            }
        }

        public bool ShouldSerializeConcatenationOfContainers()

        {
            return false;
        }

        [XmlElement("CONNR2")]
        public List<CONNR2> CONNR2
        {
            get { return _connr2; }
            set
            {
                _connr2 = value;
                OnPropertyChanged("CONNR2");
            }
        }


        [XmlElement("PACGS2")]
        public PACGS2 PACGS2
        {
            get { return _pacgs2; }
            set
            {
                _pacgs2 = value;
                OnPropertyChanged("PACGS2");
            }
        }

        public bool ShouldSerializePACGS2()
        {
            return PACGS2.KinOfPacGS23 != null &&
                   PACGS2.MarNumOfPacGS21 != null &&
                   PACGS2.MarNumOfPacGS21LNG != null &&
                   PACGS2.NumOfPacGS24 != null;
        }


        [XmlElement("TAXADDELE100")]
        public TAXADDELE100 TAXADDELE100
        {
            get { return _taxaddele100; }
            set
            {
                _taxaddele100 = value;
                OnPropertyChanged("TAXADDELE100");
            }
        }

        public bool ShouldSerializeTAXADDELE100()
        {
            return TAXADDELE100.AmoOfSupUniTAXADDELE100 != null &&
                   TAXADDELE100.SupUniCodTAXADDELE101 != null;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}