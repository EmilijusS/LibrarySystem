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
    class GenreValidation : IValidator
    {
        public string ErrorMessage { get; } = "Neteisinga įvestis.";

        public string Message { get; } = "Be tarpų įrašykite numerius knygai tinkamų žanrų (pvz \"168\"):";

        public bool IsValid(string input)
        {
            // Copied from http://codeasp.net/blogs/microsoft-net/910/check-if-a-number-has-repeated-digits-with-regular-expression
            // Second regex somehow finds repeating digits.
            return Regex.IsMatch(input, @"^\d{1,9}$") && !Regex.IsMatch(input, @"(?<1>\d)(?<=\k<1>\d*?.)+");
        }
    }
}
