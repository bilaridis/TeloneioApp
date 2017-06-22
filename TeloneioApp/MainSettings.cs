using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using DomainModel;
using DomainModel.Models;
using Repository;

namespace TeloneioApp
{
    public static class MainSettings
    {
        public static LoginCustomerDetail CustomerDetails { get; set; }

        public static void InitializeStaticData()
        {
            CustomerDetails = new LoginCustomerDetail
            {
                LoginUserName = "bilaridis",
                LoginPassword = "bill020690",
                Name = "ΘΕΟΔΟΣΙΟΣ",
                Surname = "ΦΡΑΓΚΙΑΔΗΣ",
                Country = "GR",
                Language = "EL",
                EORI_TIN = "GR024372649"
            };
        }
    }
}
