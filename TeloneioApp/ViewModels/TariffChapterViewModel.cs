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
            int lengthThatInserted = key.Length;

            while (key.Length < 10)
            {
                key = key + "0";
            }

            var trCode = "";
            var trLevel = "";
            var trDescr = "";
            var orDefault = Chapters.FirstOrDefault(x => x.TariffKey.StartsWith(key.Substring(0, 2)));
            if (orDefault != null)
            {
                trCode = orDefault.TariffKey;
                trLevel = orDefault.Level;
                trDescr = orDefault.Descr;

                var subChapter = orDefault.SubChapters.FirstOrDefault(x => x.TariffKey.StartsWith(key.Substring(0, 4)));
                if (subChapter != null)
                {
                    trCode = subChapter.TariffKey;
                    trLevel = subChapter.Level;
                    trDescr += subChapter.Descr;

                    if (lengthThatInserted == 4)
                    {
                        ReturnTaricCode = trCode;
                        ReturnTaricLevel = trLevel;
                        ReturnTaricDescr = trDescr;
                        return;
                    }
                    var subChapters = subChapter.Chapters.Where(x => x.TariffKey.StartsWith(key.Substring(0, 5))).ToList();
                    if (subChapters.Count > 0 && subChapters.First().SubChapters.Count == 0)
                    {
                        trCode = subChapters.First().TariffKey;
                        trLevel = subChapters.First().Level;
                        trDescr += subChapters.First().Descr;
                    }
                    else
                    {
                        foreach (var items in subChapters)
                        {
                            trCode = items.TariffKey;
                            trLevel = items.Level;
                            trDescr += items.Descr;
                            foreach (var firstItem in items.SubChapters.Where(x => x.TariffKey.StartsWith(key.Substring(0, 6))))
                            {
                                trCode = firstItem.TariffKey;
                                trLevel = firstItem.Level;
                                trDescr += firstItem.Descr;
                                if (lengthThatInserted == 6) continue;
                                foreach (var item in firstItem.Chapters.Where(x => x.TariffKey.StartsWith(key.Substring(0, 8))))
                                {
                                    trCode = item.TariffKey;
                                    trLevel = item.Level;
                                    trDescr += item.Descr;
                                    if (lengthThatInserted == 8) continue;
                                    foreach (var subItems in item.SubChapters.Where(x => x.TariffKey.StartsWith(key.Substring(0, 10)))
                                    )
                                    {
                                        trCode = subItems.TariffKey;
                                        trLevel = subItems.Level;
                                        trDescr += subItems.Descr;
                                        foreach (var subItem in subItems.Chapters.Where(x => x.TariffKey.StartsWith(key)))
                                        {
                                            trCode = subItem.TariffKey;
                                            trLevel = subItem.Level;
                                            trDescr += subItem.Descr;
                                        }
                                        ReturnTaricCode = trCode;
                                        ReturnTaricLevel = trLevel;
                                        ReturnTaricDescr = trDescr;
                                        return;
                                    }
                                    ReturnTaricCode = trCode;
                                    ReturnTaricLevel = trLevel;
                                    ReturnTaricDescr = trDescr;
                                    return;
                                }
                            }
                        }
                    }
                }
            }

            ReturnTaricCode = trCode;
            ReturnTaricLevel = trLevel;
            ReturnTaricDescr = trDescr;
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
