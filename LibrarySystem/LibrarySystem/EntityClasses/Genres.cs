/* 
  Kurso "Taikomasis objektinis programavimas" (VU MIF, PS) 2016/17 m.m. rudens sem.
  1-as laboratorinis darbas "Bibliotekos sistema"
  Darbą atliko: Emilijus Stankus
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem
{
    [Flags]
    public enum Genres
    {
        Fantastika = 1,
        Drama = 2,
        Detektyvas = 4,
        Siaubo = 8,
        Veiksmo = 16,
        Nuotykių = 32,
        Romantinė = 64,
        Komedija = 128,
        Poezija = 256
    }
}
