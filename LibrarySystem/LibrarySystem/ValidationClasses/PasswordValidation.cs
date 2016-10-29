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
    class PasswordValidation : IValidator
    {
        public string ErrorMessage { get; } = "Slaptažodį turi sudaryti bent 8 simboliai.";

        public string Message { get; } = "Įveskite slaptažodį:";

        public bool IsValid(string input)
        {
            // Password must be between 8 and 50 characters long
            return Regex.IsMatch(input, @"^.{8,50}$");
        }
    }
}
