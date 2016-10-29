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

namespace LibrarySystem.ValidationClasses
{
    class AuthorValidation : IValidator
    {
        public string ErrorMessage { get; } = "Autoriaus vardas ir pavardė turi būti iki 50 simbolių ilgio.";

        public string Message { get; } = "Įveskite autoriaus vardą ir pavardę:";

        public bool IsValid(string input)
        {
            // Name must be up to 50 characters long, can contain letters, dashes, dots and spaces
            return Regex.IsMatch(input, @"^[\p{L}-\. ]{1,50}$");
        }
    }
}
