using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;

namespace DomainModel.XmlModels.ID15A
{
    public class TRACONCO1 : INotifyPropertyChanged
    {
        private string _namCo17;
        private string _strAndNumCo122;
        private string _posCodCo123;
        private string _citCo124;
        private string _couCo125;
        private string _nadlngco;

        [XmlElement("NamCO17")]
        public string NamCO17
        {
            get { return _namCo17; }
            set
            {
                _namCo17 = value;
                OnPropertyChanged("NamCO17");
            }
        }

        [XmlElement("StrAndNumCO122")]
        public string StrAndNumCO122
        {
            get { return _strAndNumCo122; }
            set
            {
                _strAndNumCo122 = value;
                OnPropertyChanged("StrAndNumCO122");
            }
        }

        [XmlElement("PosCodCO123")]
        public string PosCodCO123
        {
            get { return _posCodCo123; }
            set
            {
                _posCodCo123 = value;
                OnPropertyChanged("PosCodCO123");
            }
        }

        [XmlElement("CitCO124")]
        public string CitCO124
        {
            get { return _citCo124; }
            set
            {
                _citCo124 = value;
                OnPropertyChanged("CitCO124");
            }
        }

        [XmlElement("CouCO125")]
        public string CouCO125
        {
            get { return _couCo125; }
            set
            {
                _couCo125 = value;
                OnPropertyChanged("CouCO125");
            }
        }

        [XmlElement("NADLNGCO")]
        public string NADLNGCO
        {
            get { return _nadlngco; }
            set
            {
                _nadlngco = value;
                OnPropertyChanged("NADLNGCO");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}