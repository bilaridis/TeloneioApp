﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Repository;

namespace TeloneioApp
{
    public static class MainSettings
    {
        public static CustomerDetails CustomerDetails { get; set; }

        public static void InitializeStaticData()
        {
            CustomerDetails = new CustomerDetails
            {
                Name = "ΘΕΟΔΟΣΙΟΣ",
                Surname = "ΦΡΑΓΚΙΑΔΗΣ",
                Country = "GR",
                Language = "EL",
                Eoritin = "GR024372649"
            };
        }

        //public static bool FoundGreekLetters(string text)
        //{
        //    string pattern = @"[\p{IsGreekandCoptic}]";

        //    var result = Regex.IsMatch(text, pattern);
        //    return result;
        //    //0370 - 03FF
        //}
    }
}
