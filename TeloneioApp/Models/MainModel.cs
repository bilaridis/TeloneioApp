using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using Repository;
using TeloneioApp.Annotations;
using TeloneioApp.Models.ID15A;
using TeloneioApp.StaticResources;

namespace TeloneioApp.Models
{
    public class MainModel : INotifyPropertyChanged
    {
        private List<Customer> _customers;

        public MainModel()
        {
            Customers = new List<Customer>();

        }
       

        public List<Customer> Customers
        {
            get
            {
                return _customers; 
                
            }
            set
            {
                _customers = value;
                OnPropertyChanged("Customers");
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
