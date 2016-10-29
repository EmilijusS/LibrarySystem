/* 
  Kurso "Taikomasis objektinis programavimas" (VU MIF, PS) 2016/17 m.m. rudens sem.
  1-as laboratorinis darbas "Bibliotekos sistema"
  Darbą atliko: Emilijus Stankus
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LibrarySystem
{
    class YearValidation : IValidator
    {
        public string ErrorMessage { get; } = "Metai galimi nuo 1 iki 9999.";

        public string Message { get; } = "Įveskite knygos parašymo metus:";

        public bool IsValid(string input)
        {
            // Any year between 1 to 9999 
            return Regex.IsMatch(input, @"^[1-9]\d{0,3}$");
        }
    }
}
