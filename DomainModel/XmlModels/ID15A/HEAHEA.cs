using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;

namespace DomainModel.XmlModels.ID15A
{
    public class HEAHEA : INotifyPropertyChanged
    {
        private string _refNumHea4;
        private string _typOfDecHea24;
        private string _couOfDesCodHea30;
        private string _agrLocOfGooCodHea38;
        private string _agrLocOfGooHea39;
        private string _agrLocOfGooHea39Lng;
        private string _couOfDisCodHea55;
        private decimal _traModAtBorHea76;
        private string _ideOfMeaOfTraCroHea85;
        private string _ideOfMeaOfTraCroHea85Lng;
        private string _natOfMeaOfTraCroHea87;
        private decimal _conIndHea96;
        private int _totNumOfIteHea305;
        private int _totNumOfPacHea306;
        private decimal _totGroMasHea307;
        private decimal _decDatHea383;
        private string _decPlaHea394Lng;
        private string _typOfDecBx12Hea651;
        private string _finBanInfHea1027;
        private string _ideMeaTraArr4004;
        private string _ideMeaTraArr4005Lng;
        private string _natOfMeaOfTraAtArrHea54;
        private string _metOfPayHea590;
        private string _decPlaHea394;

        [XmlElement("RefNumHEA4")]
        public string RefNumHEA4
        {
            get { return _refNumHea4; }
            set
            {
                _refNumHea4 = value;
                OnPropertyChanged("RefNumHEA4");
            }
        }

        [XmlElement("TypOfDecHEA24")]
        public string TypOfDecHEA24
        {
            get { return _typOfDecHea24; }
            set
            {
                _typOfDecHea24 = value;
                OnPropertyChanged("TypOfDecHEA24");
            }
        }

        [XmlElement("CouOfDesCodHEA30")]
        public string CouOfDesCodHEA30
        {
            get { return _couOfDesCodHea30; }
            set
            {
                _couOfDesCodHea30 = value;
                OnPropertyChanged("CouOfDesCodHEA30");
            }
        }

        [XmlElement("AgrLocOfGooCodHEA38")]
        public string AgrLocOfGooCodHEA38
        {
            get { return _agrLocOfGooCodHea38; }
            set
            {
                _agrLocOfGooCodHea38 = value;
                OnPropertyChanged("AgrLocOfGooCodHEA38");
            }
        }

        [XmlElement("AgrLocOfGooHEA39")]
        public string AgrLocOfGooHEA39
        {
            get { return _agrLocOfGooHea39; }
            set
            {
                _agrLocOfGooHea39 = value;
                OnPropertyChanged("AgrLocOfGooHEA39");
            }
        }

        [XmlElement("AgrLocOfGooHEA39LNG")]
        public string AgrLocOfGooHEA39LNG
        {
            get { return _agrLocOfGooHea39Lng; }
            set
            {
                _agrLocOfGooHea39Lng = value;
                OnPropertyChanged("AgrLocOfGooHEA39LNG");
            }
        }

        [XmlElement("CouOfDisCodHEA55")]
        public string CouOfDisCodHEA55
        {
            get { return _couOfDisCodHea55; }
            set
            {
                _couOfDisCodHea55 = value;
                OnPropertyChanged("CouOfDisCodHEA55");
            }
        }

        [XmlElement("TraModAtBorHEA76")]
        public decimal TraModAtBorHEA76
        {
            get { return _traModAtBorHea76; }
            set
            {
                _traModAtBorHea76 = value;
                OnPropertyChanged("TraModAtBorHEA76");
            }
        }

        [XmlElement("IdeOfMeaOfTraCroHEA85")]
        public string IdeOfMeaOfTraCroHEA85
        {
            get { return _ideOfMeaOfTraCroHea85; }
            set
            {
                _ideOfMeaOfTraCroHea85 = value;
                OnPropertyChanged("IdeOfMeaOfTraCroHEA85");
            }
        }

        [XmlElement("IdeOfMeaOfTraCroHEA85LNG")]
        public string IdeOfMeaOfTraCroHEA85LNG
        {
            get { return _ideOfMeaOfTraCroHea85Lng; }
            set
            {
                _ideOfMeaOfTraCroHea85Lng = value;
                OnPropertyChanged("IdeOfMeaOfTraCroHEA85LNG");
            }
        }

        [XmlElement("NatOfMeaOfTraCroHEA87")]
        public string NatOfMeaOfTraCroHEA87
        {
            get { return _natOfMeaOfTraCroHea87; }
            set
            {
                _natOfMeaOfTraCroHea87 = value;
                OnPropertyChanged("NatOfMeaOfTraCroHEA87");
            }
        }

        [XmlElement("ConIndHEA96")]
        public decimal ConIndHEA96
        {
            get { return _conIndHea96; }
            set
            {
                _conIndHea96 = value;
                OnPropertyChanged("ConIndHEA96");
            }
        }

        [XmlElement("TotNumOfIteHEA305")]
        public int TotNumOfIteHEA305
        {
            get { return _totNumOfIteHea305; }
            set
            {
                _totNumOfIteHea305 = value;
                OnPropertyChanged("TotNumOfIteHEA305");
            }
        }

        [XmlElement("TotNumOfPacHEA306")]
        public int TotNumOfPacHEA306
        {
            get { return _totNumOfPacHea306; }
            set
            {
                _totNumOfPacHea306 = value;
                OnPropertyChanged("TotNumOfPacHEA306");
            }
        }

        [XmlElement("TotGroMasHEA307")]
        public decimal TotGroMasHEA307
        {
            get { return _totGroMasHea307; }
            set
            {
                _totGroMasHea307 = value;
                OnPropertyChanged("TotGroMasHEA307");
            }
        }

        [XmlElement("DecDatHEA383")]
        public decimal DecDatHEA383
        {
            get { return _decDatHea383; }
            set
            {
                _decDatHea383 = value;
                OnPropertyChanged("DecDatHEA383");
            }
        }

        [XmlElement("DecPlaHEA394")]
        public string DecPlaHEA394
        {
            get { return _decPlaHea394; }
            set
            {
                _decPlaHea394 = value;
                OnPropertyChanged("DecPlaHEA394");
            }
        }

        [XmlElement("DecPlaHEA394LNG")]
        public string DecPlaHEA394LNG
        {
            get { return _decPlaHea394Lng; }
            set
            {
                _decPlaHea394Lng = value;
                OnPropertyChanged("DecPlaHEA394LNG");
            }
        }

        [XmlElement("TypOfDecBx12HEA651")]
        public string TypOfDecBx12HEA651
        {
            get { return _typOfDecBx12Hea651; }
            set
            {
                _typOfDecBx12Hea651 = value;
                OnPropertyChanged("TypOfDecBx12HEA651");
            }
        }

        [XmlElement("FinBanInfHEA1027")]
        public string FinBanInfHEA1027
        {
            get { return _finBanInfHea1027; }
            set
            {
                _finBanInfHea1027 = value;
                OnPropertyChanged("FinBanInfHEA1027");
            }
        }

        [XmlElement("IdeMeaTraArr4004")]
        public string IdeMeaTraArr4004
        {
            get { return _ideMeaTraArr4004; }
            set
            {
                _ideMeaTraArr4004 = value;
                OnPropertyChanged("IdeMeaTraArr4004");
            }
        }

        [XmlElement("IdeMeaTraArr4005LNG")]
        public string IdeMeaTraArr4005LNG
        {
            get { return _ideMeaTraArr4005Lng; }
            set
            {
                _ideMeaTraArr4005Lng = value;
                OnPropertyChanged("IdeMeaTraArr4005LNG");
            }
        }

        [XmlElement("NatOfMeaOfTraAtArrHEA54")]
        public string NatOfMeaOfTraAtArrHEA54
        {
            get { return _natOfMeaOfTraAtArrHea54; }
            set
            {
                _natOfMeaOfTraAtArrHea54 = value;
                OnPropertyChanged("NatOfMeaOfTraAtArrHEA54");
            }
        }

        [XmlElement("MetOfPayHEA590")]
        public string MetOfPayHEA590
        {
            get { return _metOfPayHea590; }
            set
            {
                _metOfPayHea590 = value;
                OnPropertyChanged("MetOfPayHEA590");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}