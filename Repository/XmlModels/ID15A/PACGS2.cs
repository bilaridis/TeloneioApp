using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;

namespace DomainModel.XmlModels.ID15A
{
    public class PACGS2 :INotifyPropertyChanged
    {
        private string _marNumOfPacGs21;
        private string _marNumOfPacGs21Lng;
        private string _kinOfPacGs23;
        private int _numOfPacGs24;

        [XmlElement("MarNumOfPacGS21")]
        public string MarNumOfPacGS21
        {
            get { return _marNumOfPacGs21; }
            set
            {
                _marNumOfPacGs21 = value;
                var stringForCheck = value;
                MarNumOfPacGS21LNG = MainSettings.FoundGreekLetters(stringForCheck) ? "EL" : "EN";
                OnPropertyChanged("MarNumOfPacGS21");
            }
        }

        [XmlElement("MarNumOfPacGS21LNG")]
        public string MarNumOfPacGS21LNG
        {
            get { return _marNumOfPacGs21Lng; }
            set
            {
                _marNumOfPacGs21Lng = value;
                OnPropertyChanged("MarNumOfPacGS21LNG");
            }
        }

        [XmlElement("KinOfPacGS23")]
        public string KinOfPacGS23
        {
            get { return _kinOfPacGs23; }
            set
            {
                _kinOfPacGs23 = value;
                OnPropertyChanged("KinOfPacGS23");
            }
        }

        [XmlElement("NumOfPacGS24")]
        public int NumOfPacGS24
        {
            get { return _numOfPacGs24; }
            set
            {
                _numOfPacGs24 = value;
                OnPropertyChanged("NumOfPacGS24");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}