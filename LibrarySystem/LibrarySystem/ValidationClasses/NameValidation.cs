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
    class NameValidation : IValidator
    {
        public string ErrorMessage { get; } = "Vardas ir pavardė turi susidaryti iš dviejų žodžių iki 25 raidžių.";

        public string Message { get; } = "Įveskite vardą ir pavardę:";

        public bool IsValid(string input)
        {
            // Name must contain two words between 1 and 25 characters long in unicode letters
            return Regex.IsMatch(input, @"^[\p{L}]{1,25} [\p{L}]{1,25}$");
        }
    }
}
