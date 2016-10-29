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
    struct ReaderInfo
    {
        public readonly string BookTitle;
        public readonly string BookReturnDate;
        public readonly Reader Reader;

        public ReaderInfo(string bookTitle, string bookReturnDate, Reader reader)
        {
            BookTitle = bookTitle;
            BookReturnDate = bookReturnDate;
            Reader = reader;
        }
    }
}
