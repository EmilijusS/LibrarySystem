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
    class TitleValidation : IValidator
    {
        public string ErrorMessage { get; } = "Pavadinimas negali būti ilgesnis nei 100 simbolių";

        public string Message { get; } = "Įveskite knygos pavadinimą:";

        public bool IsValid(string input)
        {
            // 1-50 characters
            return Regex.IsMatch(input, @"^.{1,50}$");
        }
    }
}
