using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel;

namespace TeloneioApp.ViewModels
{
    public class HomeViewModel: ViewModelBaseClass
    {
        public CustomerDetails LoginCustomerDetails { get; set; }
        public HomeViewModel()
        {
            LoginCustomerDetails = MainSettings.CustomerDetails;
        }
    }
}
