using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TeloneioApp.Annotations;
using TeloneioApp.Extensions;
using TeloneioApp.HttpClients;
using TeloneioApp.StaticResources;

namespace TeloneioApp.ViewModels
{
    public class TariffChapterViewModel : INotifyPropertyChanged
    {
        private string _xmlStringBuilder;
        private string _taricCode;
        private string _returnTaricCode;
        private string _returnTaricLevel;
        private string _returnTaricDescr;

        public TariffChapterViewModel()
        {

        }
        public Chapter Chapter { get; set; }

        public string XmlStringBuilder
        {
            get { return _xmlStringBuilder; }
            set
            {
                _xmlStringBuilder = value;
                OnPropertyChanged("XmlStringBuilder");
            }
        }

        public string TaricCode
        {
            get { return _taricCode; }
            set
            {
                _taricCode = value;
                var tariffCodesHelper = new TariffCodesHelper();
                Chapter = tariffCodesHelper.GetChapterDescriptions(value);
                Chapter.GetDesciption(value, ref _returnTaricCode, ref _returnTaricLevel, ref _returnTaricDescr);
                ReturnTaricCode = _returnTaricCode;
                ReturnTaricLevel = _returnTaricLevel;
                ReturnTaricDescr = _returnTaricDescr;
                XmlStringBuilder = JsonConvert.SerializeObject(Chapter);
                OnPropertyChanged("TaricCode");
            }
        }

        public string ReturnTaricCode
        {
            get { return _returnTaricCode; }
            set
            {
                _returnTaricCode = value;
                OnPropertyChanged("ReturnTaricCode");
            }
        }

        public string ReturnTaricLevel
        {
            get { return _returnTaricLevel; }
            set
            {
                _returnTaricLevel = value;
                OnPropertyChanged("ReturnTaricLevel");
            }
        }

        public string ReturnTaricDescr
        {
            get { return _returnTaricDescr; }
            set
            {
                _returnTaricDescr = value;
                OnPropertyChanged("ReturnTaricDescr");
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
