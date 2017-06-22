using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;
using DomainModel.Annotations;

namespace DomainModel.XmlModels.ID15A
{
    public class TAXADDELE100 : INotifyPropertyChanged
    {
        private string _supUniCodTaxaddele101;
        private string _amoOfSupUniTaxaddele100;

        [XmlElement("SupUniCodTAXADDELE101")]
        public string SupUniCodTAXADDELE101
        {
            get { return _supUniCodTaxaddele101; }
            set { _supUniCodTaxaddele101 = value; }
        }

        [XmlElement("AmoOfSupUniTAXADDELE100")]
        public string AmoOfSupUniTAXADDELE100
        {
            get { return _amoOfSupUniTaxaddele100; }
            set { _amoOfSupUniTaxaddele100 = value; }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}