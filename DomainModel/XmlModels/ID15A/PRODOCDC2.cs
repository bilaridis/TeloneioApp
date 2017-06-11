using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;

namespace DomainModel.XmlModels.ID15A
{
    public class PRODOCDC2 : INotifyPropertyChanged
    {
        private string _docTypDc21;
        private string _docRefDc23;
        private string _docRefDclng;

        [XmlElement("DocTypDC21")]
        public string DocTypDC21
        {
            get { return _docTypDc21; }
            set
            {
                _docTypDc21 = value;
                var stringForCheck = value + DocRefDC23;
                DocRefDCLNG = Repository.MainSettings.FoundGreekLetters(stringForCheck) ? "EL" : "EN";
            }
        }

        [XmlElement("DocRefDC23")]
        public string DocRefDC23
        {
            get { return _docRefDc23; }
            set
            {
                _docRefDc23 = value;
                var stringForCheck = DocTypDC21 + value;
                DocRefDCLNG = Repository.MainSettings.FoundGreekLetters(stringForCheck) ? "EL" : "EN";
            }
        }

        [XmlElement("DocRefDCLNG")]
        public string DocRefDCLNG
        {
            get { return _docRefDclng; }
            set
            {
                _docRefDclng = value;
                OnPropertyChanged("DocRefDCLNG");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}