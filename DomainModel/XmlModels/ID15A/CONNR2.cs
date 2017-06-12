using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;

namespace DomainModel.XmlModels.ID15A
{
    public class CONNR2 : INotifyPropertyChanged
    {
        private string _conNumNR21;
        [XmlElement("ConNumNR21")]
        public string ConNumNR21
        {
            get
            {
                return _conNumNR21;
            }
            set
            {
                _conNumNR21 = value;
                OnPropertyChanged("ConNumNR21");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}