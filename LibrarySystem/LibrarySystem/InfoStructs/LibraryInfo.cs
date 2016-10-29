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
    struct LibraryInfo
    {
        public readonly string ReaderName;
        public readonly IEnumerable<ReaderInfo> ReaderInfo;

        public LibraryInfo(string readerName, IEnumerable<ReaderInfo> readerInfo)
        {
            ReaderName = readerName;
            ReaderInfo = readerInfo;
        }
    }
}
