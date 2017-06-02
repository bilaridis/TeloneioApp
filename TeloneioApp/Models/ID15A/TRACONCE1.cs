using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;
using TeloneioApp.Annotations;

namespace TeloneioApp.Models.ID15A
{
    public class TRACONCE1 : INotifyPropertyChanged
    {
        private string _citCe124;
        private string _couCe125;
        private string _nadlngce;
        private string _namCe17;
        private string _posCodCe123;
        private string _strAndNumCe122;
        private string _tince159;

        [XmlElement("NamCE17")]
        public string NamCE17
        {
            get => _namCe17;
            set
            {
                _namCe17 = value;
                OnPropertyChanged("NamCE17");
            }
        }

        [XmlElement("StrAndNumCE122")]
        public string StrAndNumCE122
        {
            get => _strAndNumCe122;
            set
            {
                _strAndNumCe122 = value;
                OnPropertyChanged("StrAndNumCE122");
            }
        }

        [XmlElement("PosCodCE123")]
        public string PosCodCE123
        {
            get => _posCodCe123;
            set
            {
                _posCodCe123 = value;
                OnPropertyChanged("PosCodCE123");
            }
        }

        [XmlElement("CitCE124")]
        public string CitCE124
        {
            get => _citCe124;
            set
            {
                _citCe124 = value;
                OnPropertyChanged("CitCE124");
            }
        }

        [XmlElement("CouCE125")]
        public string CouCE125
        {
            get => _couCe125;
            set
            {
                _couCe125 = value;
                OnPropertyChanged("CouCE125");
            }
        }

        [XmlElement("NADLNGCE")]
        public string NADLNGCE
        {
            get => _nadlngce;
            set
            {
                _nadlngce = value;
                OnPropertyChanged("NADLNGCE");
            }
        }

        [XmlElement("TINCE159")]
        public string TINCE159
        {
            get => _tince159;
            set
            {
                _tince159 = value;
                OnPropertyChanged("TINCE159");
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