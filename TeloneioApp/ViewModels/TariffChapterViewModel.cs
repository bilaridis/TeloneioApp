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
                searchTaricCode(value);
                OnPropertyChanged("TaricCode");

            }
        }

        private void searchTaricCode(string key)
        {
            if (key.Length <= 2)
            {
                var firstOrDefault = Chapters.FirstOrDefault(x => x.TariffKey.StartsWith(key));
                if (firstOrDefault != null)
                {
                    ReturnTaricCode = firstOrDefault.TariffKey;
                    ReturnTaricLevel = firstOrDefault.Level;
                    ReturnTaricDescr = firstOrDefault.Descr;
                }
            }
            else if (key.Length <= 4)
            {
                var orDefault = Chapters.FirstOrDefault(x => x.TariffKey.StartsWith(key.Substring(0, 2)));
                if (orDefault != null)
                {
                    ReturnTaricDescr = orDefault.Descr;

                    var firstOrDefault = orDefault.SubChapters.FirstOrDefault(x => x.TariffKey.StartsWith(key));
                    if (firstOrDefault != null)
                    {
                        ReturnTaricCode = firstOrDefault.TariffKey;
                        ReturnTaricLevel = firstOrDefault.Level;
                        ReturnTaricDescr += firstOrDefault.Descr;
                    }
                }
            }
            else if (key.Length <= 6)
            {
                var orDefault = Chapters.FirstOrDefault(x => x.TariffKey.StartsWith(key.Substring(0, 2)));
                if (orDefault != null)
                {
                    ReturnTaricDescr = orDefault.Descr;

                    var subChapter = orDefault.SubChapters.FirstOrDefault(x => x.TariffKey.StartsWith(key.Substring(0, 4)));
                    if (subChapter != null)
                    {

                        ReturnTaricDescr += subChapter.Descr;

                        var subChapters = subChapter.Chapters.Where(x => x.TariffKey.StartsWith(key.Substring(0, 5))).ToList();
                        if (subChapters.First().SubChapters.Count == 0)
                        {
                            ReturnTaricCode = subChapters.First().TariffKey;
                            ReturnTaricLevel = subChapters.First().Level;
                            ReturnTaricDescr += subChapters.First().Descr;
                        }
                        else
                        {
                            foreach (var items in subChapters)
                            {
                                foreach (var item in items.SubChapters)
                                {
                                    if (item.TariffKey.StartsWith(key))
                                    {
                                        ReturnTaricCode = item.TariffKey;
                                        ReturnTaricLevel = item.Level;
                                        ReturnTaricDescr += item.Descr;
                                    }
                                }

                            }
                        }

                    }
                }
            }
            else if (key.Length <= 8)
            {
                var orDefault = Chapters.FirstOrDefault(x => x.TariffKey.StartsWith(key.Substring(0, 2)));
                if (orDefault != null)
                {
                    ReturnTaricDescr = orDefault.Descr;

                    var subChapter = orDefault.SubChapters.FirstOrDefault(x => x.TariffKey.StartsWith(key.Substring(0, 4)));
                    if (subChapter != null)
                    {

                        ReturnTaricDescr += subChapter.Descr;

                        var subChapters = subChapter.Chapters.Where(x => x.TariffKey.StartsWith(key.Substring(0, 5))).ToList();
                        if (subChapters.First().SubChapters.Count == 0)
                        {
                            ReturnTaricCode = subChapters.First().TariffKey;
                            ReturnTaricLevel = subChapters.First().Level;
                            ReturnTaricDescr += subChapters.First().Descr;
                        }
                        else
                        {
                            foreach (var items in subChapters)
                            {
                                foreach (var item in items.SubChapters)
                                {
                                    if (item.TariffKey.StartsWith(key.Substring(0, 6)))
                                    {
                                        ReturnTaricDescr += item.Descr;
                                        foreach (var subItems in item.Chapters.Where(x => x.TariffKey.StartsWith(key)))
                                        {
                                            ReturnTaricCode = subItems.TariffKey;
                                            ReturnTaricLevel = subItems.Level;
                                            ReturnTaricDescr += subItems.Descr;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
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
