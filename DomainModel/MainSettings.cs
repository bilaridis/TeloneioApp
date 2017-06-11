using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Repository
{
    public static class MainSettings
    {
        public static bool FoundGreekLetters(string text)
        {
            string pattern = @"[\p{IsGreekandCoptic}]";

            var result = Regex.IsMatch(text, pattern);
            return result;
            //0370 - 03FF
        }
    }
}
