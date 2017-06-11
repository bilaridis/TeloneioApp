using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using DomainModel;
using TeloneioApp.Annotations;
using TeloneioApp.Models;
using TeloneioApp.Models.Commands;
using TeloneioApp.StaticResources;

namespace TeloneioApp.ViewModels
{
    public class MainViewModel : ViewModelBaseClass
    {
        private ObservableCollection<Customer> _customers;
        private Customer _selectedCustomer;
        public MainModel Model { get; set; }
        

        public LocalModel LocalModel { get; set; }

        public ObservableCollection<Customer> Customers
        {
            get
            {
                return _customers;

            }
            set
            {
                _customers = value;
                RaisePropertyChanged("Customers");
            }
        }

        public Customer SelectedCustomer
        {
            get { return _selectedCustomer; }
            set
            {
                _selectedCustomer = value;
                RaisePropertyChanged("SelectedCustomer");

            }
        }

        private CommandMap _commands;
        public CommandMap Commands { get { return _commands; } }

        public MainViewModel()
        {
            Model = new MainModel();
            Customers = new ObservableCollection<Customer>();
            LocalModel = new LocalModel();
            _commands = new CommandMap();

            _commands.AddCommand("Add", x => Add(), x => !CanSave());
            _commands.AddCommand("Save", x => Save(), x => CanSave());
            _commands.AddCommand("Cancel", x => Cancel(), x => CanSave());
            _commands.AddCommand("Delete", x => Delete(), x => !CanSave());
            LoadData();


        }

        private void LoadData()
        {
            Customers.Clear();
            var query = LocalModel.Customers.ToList();
            foreach (var item in query)
            {
                Customers.Add(item);
            }
        }

        void Add()
        {
            Customer customer = new Customer();
            Customers.Add(customer);
            LocalModel.Entry(customer).State = EntityState.Added;
            //LocalDBEntities.Customers.Add(customer);
            LocalModel.SaveChanges();
            SelectedCustomer = customer;
        }

        void Delete()
        {
            if (MessageBox.Show
                ("Delete selected row?",
                    "Not undoable", MessageBoxButton.YesNo,
                    MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                LocalModel.Entry(SelectedCustomer).State = EntityState.Deleted;
                //LocalDBEntities.Customers.Remove(SelectedCustomer);
                LocalModel.SaveChanges();
                Customers.Remove(SelectedCustomer);
                SelectedCustomer = Customers[0];
            }
        }

        void Save()
        {

            LocalModel.SaveChanges();
        }

        bool CanSave()
        { return LocalModel.ChangeTracker.HasChanges(); }

        void Cancel()
        {
            foreach (DbEntityEntry entry in LocalModel.ChangeTracker.Entries())
            {
                switch (entry.State)
                {
                    case EntityState.Modified:
                        entry.State = EntityState.Unchanged; break;
                    case EntityState.Added:
                        entry.State = EntityState.Detached; break;
                    case EntityState.Deleted:
                        entry.Reload(); break;
                    default: break;
                }
            }
            LoadData();
        }

        //void Close()
        //{
        //    if (CallingForm == null)
        //    { MessageBox.Show("Callingform wasn't assigned in codebehind"); }
        //    else { CallingForm.Close(); }
        //}


    }
}