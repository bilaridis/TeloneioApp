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
        public List<Chapter> Chapters { get; set; }

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
                TariffCodesHelper tariffCodesHelper = new TariffCodesHelper();
                Chapters = tariffCodesHelper.GetChapterDescriptions(value);
                XmlStringBuilder = JsonConvert.SerializeObject(Chapters);
                SearchTaricCode(value);
                OnPropertyChanged("TaricCode");
            }
        }

        private void SearchTaricCode(string key)
        {
            int keyLength = key.Length;

            while (key.Length < 10)
            {
                key = key + "0";
            }

            var trCode = "";
            var trLevel = "";
            var trDescr = "";
            var HSChapter = Chapters.FirstOrDefault(x => x.TariffKey.StartsWith(key.Substring(0, 2)));
            var HSHeading = new Chapter();
            var HSSubHeading = new Chapter();
            var CNSubHeading = new Chapter();
            var TaricSubHeading = new Chapter();

            if (HSChapter != null)
            {
                trCode = HSChapter.TariffKey;
                trLevel = HSChapter.Level;
                trDescr = HSChapter.Descr;

                HSHeading = CheckSubHeading(key, keyLength, 4, HSChapter, ref trCode, ref trLevel, ref trDescr);
                HSSubHeading = CheckSubHeading(key, keyLength, 6, HSHeading, ref trCode, ref trLevel, ref trDescr);
                CNSubHeading = CheckSubHeading(key, keyLength, 8, HSSubHeading, ref trCode, ref trLevel, ref trDescr);
                TaricSubHeading = CheckSubHeading(key, keyLength, 10, CNSubHeading, ref trCode, ref trLevel, ref trDescr);
            }

            ReturnTaricCode = trCode;
            ReturnTaricLevel = trLevel;
            ReturnTaricDescr = trDescr;
        }

        private static Chapter CheckSubHeading(string key, int keyLength, int lengthToCHeck, Chapter fatherChapter,
            ref string trCode, ref string trLevel, ref string trDescr)
        {
            Chapter tempChapter;
            if (keyLength < lengthToCHeck) return null;
            if (fatherChapter == null) return null;
            var tempLisr = fatherChapter.SubChapters.Where(x => x.TariffKey.Substring(0, lengthToCHeck).Equals(key.Substring(0, lengthToCHeck)))
                .ToList();
            var tempLisr2 = fatherChapter.SubChapters.Where(x => x.TariffKey.Substring(0, lengthToCHeck - 1).Equals(key.Substring(0, 5)))
                .ToList();
            if (tempLisr.Count > 0)
            {
                tempChapter = tempLisr.FirstOrDefault();
            }
            else if (tempLisr2.Count > 0)
            {
                var lastChapter = tempLisr2.FirstOrDefault();
                var tempList = lastChapter?.SubChapters
                    .Where(x => x.TariffKey.Substring(0, lengthToCHeck).Equals(key.Substring(0, lengthToCHeck))).ToList();
                tempChapter = tempList?.FirstOrDefault();
            }
            else
            {
                var lastChapter = fatherChapter.SubChapters.LastOrDefault();
                var tempList = lastChapter?.SubChapters
                    .Where(x => x.TariffKey.Substring(0, lengthToCHeck).Equals(key.Substring(0, lengthToCHeck))).ToList();
                tempChapter = tempList?.FirstOrDefault();
            }
            if (tempChapter == null) return null;
            trCode = tempChapter.TariffKey;
            trLevel = tempChapter.Level;
            trDescr += tempChapter.Descr;
            return tempChapter;
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
