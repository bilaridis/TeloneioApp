using DomainModel;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using DomainModel.Models;
using TeloneioApp.Annotations;

namespace TeloneioApp.Models
{
    public class CustomersModel : INotifyPropertyChanged
    {
        private List<Customer> _customers;

        public CustomersModel()
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
