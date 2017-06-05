﻿using Repository;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using TeloneioApp.Annotations;

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
