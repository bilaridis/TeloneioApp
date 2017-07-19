using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using DomainModel;
using DomainModel.Models;
using Repository;
using System.IO;
using System.Reflection;

namespace TeloneioApp
{
    public static class MainSettings
    {
        public static LoginCustomerDetail CustomerDetails { get; set; }

        public static string Applicationpath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

        public static string GetUserAppDataPath()
        {
            string path = string.Empty;
            Assembly assm;
            Type at;
            Type at1;
            object[] r;
            object[] r1;

            // Get the .EXE assembly
            assm = Assembly.GetEntryAssembly();
            // Get a 'Type' of the AssemblyCompanyAttribute
            at = typeof(AssemblyCompanyAttribute);
            at1 = typeof(AssemblyTitleAttribute);
            // Get a collection of custom attributes from the .EXE assembly
            r = assm.GetCustomAttributes(at, false);
            r1 = assm.GetCustomAttributes(at1, false);
            // Get the Company Attribute
            AssemblyCompanyAttribute ct = ((AssemblyCompanyAttribute)(r[0]));
            // Get the Company Attribute
            AssemblyTitleAttribute title = ((AssemblyTitleAttribute)(r1[0]));
            // Build the User App Data Path
            path = Environment.GetFolderPath(
                        Environment.SpecialFolder.ApplicationData);
            path += @"\" + ct.Company + @"\" + title.Title;
            path += @"\" + assm.GetName().Version.ToString();

            return path;
        }

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

        public static void CreateAppDataFiles()
        {
            if (!Directory.Exists(@"" + GetUserAppDataPath()))
                Directory.CreateDirectory(@"" + GetUserAppDataPath());
            if (!Directory.Exists(@"" + GetUserAppDataPath() + $@"\Examples"))
                Directory.CreateDirectory(@"" + GetUserAppDataPath() + $@"\Examples");
            if (File.Exists(@"" + GetUserAppDataPath() + $@"\Examples\ED000988.xml"))
            {

            }
            else
            {
                File.Copy(Applicationpath.Replace("\\bin\\Debug", "") + @"\Examples\ED000988.xml", @"" + GetUserAppDataPath() + @"\Examples\ED000988.xml");
            }
        }
    }
}
