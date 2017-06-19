using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;

namespace DomainModel.XmlModels.ID15A
{
    public class COMCODGODITM : INotifyPropertyChanged
    {
        private long _comNomCmd1;
        private int _tarCodCmd1;
        private int _tarFirAddCodCmd1;
        private int _tarSecAddCodCmd1;
        private int _nAtAddCodCmd1;

        [XmlElement("ComNomCMD1")]
        public long ComNomCMD1
        {
            get { return _comNomCmd1; }
            set
            {
                _comNomCmd1 = value;
                OnPropertyChanged("ComNomCMD1");
            }
        }

        [XmlElement("TARCodCMD1")]
        public int TARCodCMD1
        {
            get { return _tarCodCmd1; }
            set
            {
                _tarCodCmd1 = value;
                OnPropertyChanged("TARCodCMD1");
            }
        }

        [XmlElement("TARFirAddCodCMD1")]
        public int TARFirAddCodCMD1
        {
            get { return _tarFirAddCodCmd1; }
            set
            {
                _tarFirAddCodCmd1 = value;
                OnPropertyChanged("TARFirAddCodCMD1");
            }
        }

        [XmlElement("TARSecAddCodCMD1")]
        public int TARSecAddCodCMD1
        {
            get { return _tarSecAddCodCmd1; }
            set
            {
                _tarSecAddCodCmd1 = value;
                OnPropertyChanged("TARSecAddCodCMD1");
            }
        }

        [XmlElement("NAtAddCodCMD1")]
        public int NAtAddCodCMD1
        {
            get { return _nAtAddCodCmd1; }
            set
            {
                _nAtAddCodCmd1 = value;
                OnPropertyChanged("NAtAddCodCMD1");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}