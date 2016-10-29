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
    [Serializable]
    class BookCopy
    {
        public readonly string ISBN;
        public DateTime ReturnDate { get; private set; }
        private Reader _reader;
        public Reader Reader
        {
            get{return _reader;}
            set
            {
                _reader = value;
                ReturnDate = DateTime.Today;
                extendReturnDate();
            }
        }

        public BookCopy(string ISBNparam)
        {
            ISBN = ISBNparam;
            _reader = null;
        }

        public void extendReturnDate()
        {
            ReturnDate = ReturnDate.AddMonths(1);
        }
        
    }
}
