using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;

namespace DomainModel.XmlModels.ID15A
{
    public class ENTCUSOFF : INotifyPropertyChanged
    {
        private string _EnCusOffRefNum01;
        [XmlElement("EnCusOffRefNum01")]
        public string EnCusOffRefNum01
        {
            get
            {
                return _EnCusOffRefNum01;
            }
            set
            {
                _EnCusOffRefNum01 = value;
                OnPropertyChanged("EnCusOffRefNum01");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}