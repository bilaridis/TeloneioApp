using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;

namespace DomainModel.XmlModels.ID15A
{
    public class TRADAT : INotifyPropertyChanged
    {
        private string _curTrd1;
        private decimal? _totAmoInvTrd1;
        private decimal? _excRatTrd1;

        [XmlElement("CurTRD1")]
        public string CurTRD1
        {
            get { return _curTrd1; }
            set
            {
                _curTrd1 = value;
                OnPropertyChanged("CurTRD1");
            }
        }

        [XmlElement("TotAmoInvTRD1")]
        public decimal? TotAmoInvTRD1
        {
            get { return _totAmoInvTrd1; }
            set
            {
                _totAmoInvTrd1 = value;
                OnPropertyChanged("TotAmoInvTRD1");
            }
        }

        [XmlElement("ExcRatTRD1")]
        public decimal? ExcRatTRD1
        {
            get { return _excRatTrd1; }
            set
            {
                _excRatTrd1 = value;
                OnPropertyChanged("ExcRatTRD1");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}