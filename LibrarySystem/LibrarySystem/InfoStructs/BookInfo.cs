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
    struct BookInfo
    {
        public Book Book { get; private set; }
        public  IEnumerable<BookCopy> BookCopies { get; private set; }

        public BookInfo(Book book, IEnumerable<BookCopy> bookCopies)
        {
            Book = book;
            BookCopies = bookCopies;
        }
    }
}
