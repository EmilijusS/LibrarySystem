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
    class Supervisor : User
    {
        [NonSerialized]
        private List<Reader> _readers;
        [NonSerialized]
        private List<Book> _books;
        [NonSerialized]
        private List<BookCopy> _bookCopies;

        public Supervisor(string name, string personalIdentityNumber, string password,
            List<Reader> readerListP, List<Book> bookListP, List<BookCopy> bookCopyListP)
            : base(name, personalIdentityNumber, password)
        {
            _readers = readerListP;
            _books = bookListP;
            _bookCopies = bookCopyListP;
        }

        public IEnumerable<LibraryInfo> GetLibraryInfo()
        {
            var resultTemp = from bc in _bookCopies
                             join b in _books on bc.ISBN equals b.ISBN
                             select new ReaderInfo(b.Title, bc.ReturnDate.ToShortDateString(), bc.Reader);

            var result = from r in _readers
                         join bc in resultTemp on r equals bc.Reader into g
                         select new LibraryInfo(r.Name, g);

            return result;
        }

    }
}
