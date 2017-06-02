using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.IO;
using System.Linq;
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
        private Customer _apostoleas;

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
            ID15AFolder = "C:\\Repositories\\TeloneioApp\\Examples\\";
            //ID15AFolder = "C:\\Users\\billi\\Documents\\Visual Studio 2017\\Projects\\TeloneioApp\\TeloneioApp\\Examples\\"; //AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Debug\\", "\\") + "\\Examples\\";
            Selectfolders(ID15AFolder);
            Customers = new ObservableCollection<Customer>();
            using (var model = new LocalModel())
            {
                foreach (var modelCustomer in model.Customers)
                {
                    Customers.Add(modelCustomer);
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

        public Customer Apostoleas
        {
            get { return _apostoleas; }
            set
            {
                _apostoleas = value;
                this.Items.FirstOrDefault().TRACONCO1.NamCO17 = _apostoleas.Name;
                NotifyPropertyChanged("TRACONCO1.NamCO17");
                this.Items.FirstOrDefault().TRACONCO1.StrAndNumCO122 = _apostoleas.Street;
                NotifyPropertyChanged("TRACONCO1.StrAndNumCO122");
                this.Items.FirstOrDefault().TRACONCO1.PosCodCO123 = _apostoleas.PostalCode;
                NotifyPropertyChanged("TRACONCO1.PosCodCO123");
                this.Items.FirstOrDefault().TRACONCO1.CitCO124 = _apostoleas.City;
                NotifyPropertyChanged("TRACONCO1.CitCO124");
                this.Items.FirstOrDefault().TRACONCO1.CouCO125 = _apostoleas.Country;
                NotifyPropertyChanged("TRACONCO1.CouCO125");
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
                _showOriginal = value;
                NotifyPropertyChanged("IsVisibleOriginal");
            }
        }

        public bool IsVisibleForm
        {
            get => _showForm;
            set
            {
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