using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DomainModel;
using DomainModel.Models;
using TeloneioApp.ViewModels.Commands;

namespace TeloneioApp.ViewModels
{
    public class LoginViewModel : ViewModelBaseClass
    {
        private string _userName;
        private string _password;

        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        public LoginCustomerDetail LoginCustomerDetails { get; set; }
        public LoginCommand LoginCommand { get; set;}
        public LoginViewModel()
        {
            LoginCustomerDetails = MainSettings.CustomerDetails;
            LoginCommand = new LoginCommand(this);
            
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
            using (var model = new LocalModel())
            {
                if (model.LoginCustomerDetails.Any(x => x.LoginUserName == UserName))
                {
                    byte[] array = GetBytes(Password);
                    SHA512 shaM = new SHA512Managed();
                    var result = shaM.ComputeHash(array);
                    if (GetString(result) == model.LoginCustomerDetails.FirstOrDefault(x => x.LoginUserName == UserName).LoginPassword)
                    {
                        MessageBox.Show("Success");
                    }
                }

            }
            
        }
    }
}
