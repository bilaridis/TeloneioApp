using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;

namespace DomainModel.XmlModels.ID15A
{
    public class STATREP385 : INotifyPropertyChanged
    {
        private string _repStatCodStatrep386;

        [XmlElement("RepStatCodSTATREP386")]
        public string RepStatCodSTATREP386
        {
            get { return _repStatCodStatrep386; }
            set
            {
                _repStatCodStatrep386 = value;
                OnPropertyChanged("RepStatCodSTATREP386");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}