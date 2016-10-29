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
    class PersonalIdentityNumberValidation : IValidator
    {
        public string ErrorMessage { get; } = "Neteisingas asmens kodo formatas.";

        public string Message { get; } = "Įveskite savo asmens kodą:";

        public bool IsValid(string input)
        {
            // First digit 1 to 6, then birth year, month, day and any 4 digits
            return Regex.IsMatch(input, @"^[1-6][0-9]{2}(0[1-9]|1[012])(0[1-9]|[12][0-9]|3[01])[0-9]{4}$");
        }
    }
}
