﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using TeloneioApp.Models;
using TeloneioApp.Models.Commands;
using TeloneioApp.StaticResources;

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

        public ImportFormViewModel()
        {
            SaveCommand = new SaveCommand(this);

            ImportCommand = new ImportCommand(this);
            SelectFileCommand = new SelectFileCommand(this);
            ShowXml = new ShowXml(this);
            NotImplementedCommand = new NotImplementedCommand();

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

            //Add(new MainModel());
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
                this.Items.FirstOrDefault().TRACONCO1.NamCO17 = _apostoleas.Name;
                this.Items.FirstOrDefault().TRACONCO1.StrAndNumCO122 = _apostoleas.Street;
                this.Items.FirstOrDefault().TRACONCO1.PosCodCO123 = _apostoleas.PostalCode;
                this.Items.FirstOrDefault().TRACONCO1.CitCO124 = _apostoleas.City;
                this.Items.FirstOrDefault().TRACONCO1.CouCO125 = _apostoleas.Country;
                this.Items.FirstOrDefault().TRACONCO1.NADLNGCO = _apostoleas.Language;
            }
        }

        public static bool FoundGreekLetters(string text)
        {
            const string pattern = @"[\s\p{IsGreekandCoptic}]";

            return Regex.IsMatch(text, pattern);
        }

        public Customer Paraliptis
        {
            get { return _paraliptis; }
            set
            {
                _paraliptis = value;
                this.Items.FirstOrDefault().TRACONCE1.NamCE17 = _paraliptis.Name;
                this.Items.FirstOrDefault().TRACONCE1.StrAndNumCE122 = _paraliptis.Street;
                this.Items.FirstOrDefault().TRACONCE1.PosCodCE123 = _paraliptis.PostalCode;
                this.Items.FirstOrDefault().TRACONCE1.CitCE124 = _paraliptis.City;
                this.Items.FirstOrDefault().TRACONCE1.CouCE125 = _paraliptis.Country;
                this.Items.FirstOrDefault().TRACONCE1.NADLNGCE = _paraliptis.Language;
                this.Items.FirstOrDefault().TRACONCE1.TINCE159 = _paraliptis.EORI_TIN;
            }
        }

        public NotImplementedCommand NotImplementedCommand { get; set; }

        public SaveCommand SaveCommand { get; set; }

        public ImportCommand ImportCommand { get; set; }

        public SelectFileCommand SelectFileCommand { get; set; }

        public ShowXml ShowXml { get; set; }

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

        private void InitPredefinedEntries()
        {
            var apostoleas = Customers.FirstOrDefault(x =>
            {
                var importFormModel = this.Items.FirstOrDefault();
                return importFormModel != null && x.Name == importFormModel.TRACONCO1.NamCO17;
            });
            Apostoleas = CheckIfCustomerIsInDatabase(apostoleas);
            var paraliptis = Customers2.FirstOrDefault(x =>
            {
                var importFormModel = this.Items.FirstOrDefault();
                return importFormModel != null && x.Name == importFormModel.TRACONCE1.NamCE17;
            });
            Paraliptis = CheckIfCustomerIsInDatabase(paraliptis);
        }

        private Customer CheckIfCustomerIsInDatabase(Customer tempCustomer)
        {
            if (tempCustomer == null)
            {
                using (var model = new LocalModel())
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