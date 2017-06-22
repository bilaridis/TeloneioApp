using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;
using DomainModel.Annotations;
using DomainModel.XmlModels.Enums;

namespace DomainModel.XmlModels.ID15A
{
    public class CALTAXGOD : INotifyPropertyChanged
    {
        private string _typOfTaxCtx1;
        private decimal _taxBasCtx1;
        private decimal _ratOfTaxCtx1;
        private decimal _amoOfTaxTcl1;
        private TypeOfPayments _metOfPayCtx1;

        [XmlElement("TypOfTaxCTX1")]
        public string TypOfTaxCTX1
        {
            get { return _typOfTaxCtx1; }
            set
            {
                _typOfTaxCtx1 = value;
                OnPropertyChanged("TypOfTaxCTX1");
            }
        }

        [XmlElement("TaxBasCTX1")]
        public decimal TaxBasCTX1
        {
            get { return _taxBasCtx1; }
            set
            {
                _taxBasCtx1 = value;
                OnPropertyChanged("TaxBasCTX1");
            }
        }

        [XmlElement("RatOfTaxCTX1")]
        public decimal RatOfTaxCTX1
        {
            get { return _ratOfTaxCtx1; }
            set
            {
                _ratOfTaxCtx1 = value;
                OnPropertyChanged("RatOfTaxCTX1");
            }
        }

        [XmlElement("AmoOfTaxTCL1")]
        public decimal AmoOfTaxTCL1
        {
            get { return _amoOfTaxTcl1; }
            set
            {
                _amoOfTaxTcl1 = value;
                OnPropertyChanged("AmoOfTaxTCL1");
            }
        }

        [XmlElement("MetOfPayCTX1")]
        public TypeOfPayments MetOfPayCTX1
        {
            get { return _metOfPayCtx1; }
            set
            {
                _metOfPayCtx1 = value;
                OnPropertyChanged("MetOfPayCTX1");
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