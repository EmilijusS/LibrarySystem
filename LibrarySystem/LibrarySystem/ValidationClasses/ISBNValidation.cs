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
    class ISBNValidation : IValidator
    {
        public string ErrorMessage { get; } = "ISBN kodas turi susidėti iš 13 skaitmenų.";

        public string Message { get; } = "Įveskite knygos ISBN:";

        public bool IsValid(string input)
        {
            // 13 digits
            return Regex.IsMatch(input, @"^[0-9]{13}$");
        }
    }
}
