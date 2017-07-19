﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DomainModel;
using DomainModel.Models;

namespace TeloneioApp.ViewModels
{
    public class LoginViewModel: ViewModelBaseClass
    {
        public LoginCustomerDetail LoginCustomerDetails { get; set; }
        byte[] data = new byte[255];
        byte[] result;
        public LoginViewModel()
        {
            LoginCustomerDetails = MainSettings.CustomerDetails;


            byte[] array = GetBytes(LoginCustomerDetails.LoginPassword);
            SHA512 shaM = new SHA512Managed();
            var result = shaM.ComputeHash(array);

            var ExtrString = GetString(result);

            using (var model = new LocalModel())
            {
                if (!model.LoginCustomerDetails.Any(x => x.LoginUserName == LoginCustomerDetails.LoginUserName))
                {
                    var gg = Guid.NewGuid();
                    LoginCustomerDetails.GUID = gg.ToString();
                    LoginCustomerDetails.LoginUserName = "bilaridis";
                    LoginCustomerDetails.LoginPassword = ExtrString;
                    model.LoginCustomerDetails.Add(LoginCustomerDetails);

                    model.SaveChanges();
                }
                
            }
        }

        static byte[] GetBytes(string str)
        {
            byte[] bytes = new byte[str.Length * sizeof(char)];
            System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }

        static string GetString(byte[] bytes)
        {
            char[] chars = new char[bytes.Length / sizeof(char)];
            System.Buffer.BlockCopy(bytes, 0, chars, 0, bytes.Length);
            return new string(chars);
        }
        
        public void LoginClick()
        {
            
            
        }
    }
}
