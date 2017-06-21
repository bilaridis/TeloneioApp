using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using DomainModel.XmlModels.ID15A;
using DomainModel;
using TeloneioApp.Models;
using TeloneioApp.StaticResources;
using TeloneioApp.ViewModels.Commands;

namespace TeloneioApp.ViewModels
{
    public class ImportFormViewModel : ObservableCollection<ImportFormModel>
    {
        private readonly string ID15AFolder;
        private List<FileInfoEDE> _files;
        private bool _showForm;
        private bool _showOriginal;
        private ObservableCollection<Customer> _customers;
        private ObservableCollection<Customer> _customers2;
        private Customer _apostoleas;
        private Customer _paraliptis;
        private DateTime _createdDateTime;
        private string _concatenationOfContainers;

        public ImportFormViewModel()
        {
            SaveCommand = new SaveCommand(this);

            ImportCommand = new ImportCommand(this);
            SelectFileCommand = new SelectFileCommand(this);
            ShowXml = new ShowXml(this);
            NotImplementedCommand = new NotImplementedCommand();
            AddNewFormCommand = new AddNewFormCommand(this);
            AddNewClassCommand = new AddNewClassCommand(this);


            IsVisibleForm = true;
            IsVisibleOriginal = false;

            Files = new List<FileInfoEDE>();
            ID15AFolder = "C:\\Repositories\\TeloneioApp\\TeloneioApp\\Examples\\";
            //ID15AFolder = "C:\\Users\\billi\\Documents\\Visual Studio 2017\\Projects\\TeloneioApp\\TeloneioApp\\Examples\\"; //AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Debug\\", "\\") + "\\Examples\\";
            Selectfolders(ID15AFolder);
            Customers = new ObservableCollection<Customer>();
            Customers2 = new ObservableCollection<Customer>();
            using (var model = new LocalModel())
            {
                foreach (var modelCustomer in model.Customers)
                {
                    Customers.Add(modelCustomer);
                    Customers2.Add(modelCustomer);
                }
            }

            CollectionChanged += TonnageListViewModel_CollectionChanged;

            //Add(new CustomersModel());
        }

        public DateTime CreatedDateTime
        {
            get { return _createdDateTime; }
            set
            {
                _createdDateTime = value;
                var importFormModel = Items.FirstOrDefault();
                if (importFormModel != null)
                {
                    importFormModel.DatOfPreMES9 = (value.Year - 2000).ToString("D2") + value.ToString("MM") + value.Day.ToString("D2");
                    importFormModel.HEAHEA.DecDatHEA383 = (value.Year).ToString("D2") + value.ToString("MM") + value.Day.ToString("D2");
                    importFormModel.TimOfPreMES10 = value.ToString("HHmm");
                }
                NotifyPropertyChanged("CreatedDateTime");
            }
        }

        public string ConcatenationOfContainers
        {
            get { return _concatenationOfContainers; }
            set
            {
                _concatenationOfContainers = value; 

            }
        }


        public ObservableCollection<Customer> Customers
        {
            get { return _customers; }
            set { _customers = value; }
        }
        public ObservableCollection<Customer> Customers2
        {
            get { return _customers2; }
            set { _customers2 = value; }
        }

        public Customer Apostoleas
        {
            get { return _apostoleas; }
            set
            {
                _apostoleas = value;
                var importFormModel = Items.FirstOrDefault();
                if (importFormModel != null)
                {
                    importFormModel.TRACONCO1.NamCO17 = _apostoleas.Name;
                    importFormModel.TRACONCO1.StrAndNumCO122 = _apostoleas.Street;
                    importFormModel.TRACONCO1.PosCodCO123 = _apostoleas.PostalCode;
                    importFormModel.TRACONCO1.CitCO124 = _apostoleas.City;
                    importFormModel.TRACONCO1.CouCO125 = _apostoleas.Country;
                    importFormModel.TRACONCO1.NADLNGCO = _apostoleas.Language;
                    importFormModel.HEAHEA.CouOfDisCodHEA55 = _apostoleas.Country;
                }
            }
        }



        public Customer Paraliptis
        {
            get { return _paraliptis; }
            set
            {
                _paraliptis = value;
                var importFormModel = Items.FirstOrDefault();
                if (importFormModel != null)
                {
                    importFormModel.TRACONCE1.NamCE17 = _paraliptis.Name;
                    importFormModel.TRACONCE1.StrAndNumCE122 = _paraliptis.Street;
                    importFormModel.TRACONCE1.PosCodCE123 = _paraliptis.PostalCode;
                    importFormModel.TRACONCE1.CitCE124 = _paraliptis.City;
                    importFormModel.TRACONCE1.CouCE125 = _paraliptis.Country;
                    importFormModel.TRACONCE1.NADLNGCE = _paraliptis.Language;
                    importFormModel.TRACONCE1.TINCE159 = _paraliptis.EORI_TIN;
                    importFormModel.HEAHEA.CouOfDesCodHEA30 = _paraliptis.Country;
                }
            }
        }

        public NotImplementedCommand NotImplementedCommand { get; set; }

        public SaveCommand SaveCommand { get; set; }

        public ImportCommand ImportCommand { get; set; }

        public SelectFileCommand SelectFileCommand { get; set; }

        public ShowXml ShowXml { get; set; }

        public AddNewFormCommand AddNewFormCommand { get; set; }

        public AddNewClassCommand AddNewClassCommand { get; set; }

        public bool IsVisibleOriginal
        {
            get => _showOriginal;
            set
            {
                var importFormModel = Items.FirstOrDefault();
                if (importFormModel != null) importFormModel.RefreshXmlString();
                _showOriginal = value;
                NotifyPropertyChanged("IsVisibleOriginal");
            }
        }

        public bool IsVisibleForm
        {
            get => _showForm;
            set
            {
                var importFormModel = Items.FirstOrDefault();
                if (importFormModel != null) importFormModel.RefreshXmlString();
                _showForm = value;
                NotifyPropertyChanged("IsVisibleForm");
            }
        }

        public List<FileInfoEDE> Files
        {
            get => _files;
            set
            {
                _files = value;
                NotifyPropertyChanged("Files");
            }
        }

        public string SelectedFile { get; set; }

        public void SelectFile(FileInfoEDE fileInfoEde)
        {
            Clear();
            var obj = XmlExtension.XmlReaderForID15A(fileInfoEde.FullName);
            var mainModel = new ImportFormModel(obj);
            Add(mainModel);

            InitPredefinedEntries();
        }

        public void AddNewForm()
        {
            Clear();
            CreatedDateTime = DateTime.Now;
            Add(new ImportFormModel(CreatedDateTime));
        }
        public void AddNewClass()
        {
            var importFormModel = Items.FirstOrDefault();
            var newClassId = importFormModel.GOOITEGDS.Count + 1;
            if (importFormModel != null)
            {
                var newClass = new GOOITEGDS(newClassId);
                importFormModel.AddToGoods(newClass);
            }
            //NotifyPropertyChanged("GOOITEGDS");
        }

        private void InitPredefinedEntries()
        {
            var importFormModel = this.Items.FirstOrDefault();
            var apostoleas = Customers.FirstOrDefault(x =>
            {
                return importFormModel != null && x.Name == importFormModel.TRACONCO1.NamCO17;
            });
            Apostoleas = CheckIfCustomerIsInDatabase(apostoleas, "1");
            var paraliptis = Customers2.FirstOrDefault(x =>
            {
                return importFormModel != null && x.Name == importFormModel.TRACONCE1.NamCE17;
            });
            Paraliptis = CheckIfCustomerIsInDatabase(paraliptis, "2");
        }

        private Customer CheckIfCustomerIsInDatabase(Customer tempCustomer, string switcher)
        {
            if (tempCustomer == null)
            {
                using (var model = new LocalModel())
                {
                    if (switcher == "1")
                    {
                        var newCustom = new Customer
                        {
                            Name = Items.FirstOrDefault().TRACONCO1.NamCO17,
                            Street = Items.FirstOrDefault().TRACONCO1.StrAndNumCO122,
                            PostalCode = Items.FirstOrDefault().TRACONCO1.PosCodCO123,
                            City = Items.FirstOrDefault().TRACONCO1.CitCO124,
                            Country = Items.FirstOrDefault().TRACONCO1.CouCO125,
                            Language = Items.FirstOrDefault().TRACONCO1.NADLNGCO
                        };
                        model.Customers.Add(newCustom);

                        model.SaveChanges();
                        Customers2.Add(newCustom);
                        return newCustom;
                    }
                    else
                    {
                        var newCustom = new Customer
                        {
                            Name = Items.FirstOrDefault().TRACONCE1.NamCE17,
                            Street = Items.FirstOrDefault().TRACONCE1.StrAndNumCE122,
                            PostalCode = Items.FirstOrDefault().TRACONCE1.PosCodCE123,
                            City = Items.FirstOrDefault().TRACONCE1.CitCE124,
                            Country = Items.FirstOrDefault().TRACONCE1.CouCE125,
                            Language = Items.FirstOrDefault().TRACONCE1.NADLNGCE,
                            EORI_TIN = Items.FirstOrDefault().TRACONCE1.TINCE159
                        };
                        model.Customers.Add(newCustom);

                        model.SaveChanges();
                        Customers2.Add(newCustom);
                        return newCustom;
                    }


                }
            }
            else
            {
                return tempCustomer;
            }
        }

        private void TonnageListViewModel_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            //MessageBox.Show(e.Action.ToString());
        }

        public void Selectfolders(string path)
        {
            var dirInfo = new DirectoryInfo(path);

            var info = dirInfo.GetFiles("*.*");
            foreach (var f in info)
            {
                var fclass = new FileInfoEDE
                {
                    Name = f.Name,
                    length = Convert.ToUInt32(f.Length),
                    DirectoryName = f.DirectoryName,
                    FullName = f.FullName,
                    Extension = f.Extension
                };
                Files.Add(fclass);
            }
            var subDirectories = dirInfo.GetDirectories();
            foreach (var directory in subDirectories)
                Selectfolders(directory.FullName);
        }

        protected override event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(string info)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));
        }

        public override event NotifyCollectionChangedEventHandler CollectionChanged
        {
            add => base.CollectionChanged += value;
            remove => base.CollectionChanged -= value;
        }
    }
}