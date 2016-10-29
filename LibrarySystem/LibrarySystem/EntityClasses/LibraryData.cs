using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem
{
    struct LibraryData
    {
        public readonly Supervisor Supervisor;
        public readonly List<Reader> Readers;
        public readonly List<Book> Books;
        public readonly List<BookCopy> BookCopies;
          
        public LibraryData(Supervisor supervisor, List<Reader> readers, List<Book> books, List<BookCopy> bookCopies)
        {
            Supervisor = supervisor;
            Readers = readers;
            Books = books;
            BookCopies = bookCopies;
        }
    }
}
