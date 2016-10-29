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
    class Reader : User
    {
        public readonly int MaxBooksTaken = 5;
        public List<BookCopy> BooksTaken { get; private set; }

        public Reader(string name, string personalIdentityNumber, string password)
            : base(name, personalIdentityNumber, password)
        {
            BooksTaken = new List<BookCopy>();
        }


        public void TakeBook(BookCopy bookCopy)
        {
            if (bookCopy.Reader != null)
            {
                throw new ArgumentException("bookCopy.Reader must be null", "bookCopy");
            }

            if(BooksTaken.Count == MaxBooksTaken)
            {
                throw new InvalidOperationException($"Jūs jau turite pasiėmęs maksimalų galimą knygų kiekį ({MaxBooksTaken}).");
            }
                
            bookCopy.Reader = this;
            BooksTaken.Add(bookCopy);
        }
            
        public void ReturnBook(BookCopy bookCopy)
        {
            if(!BooksTaken.Contains(bookCopy))
            {
                throw new ArgumentException("BooksTaken must contain bookCopy", "bookCopy");
            }

            BooksTaken.Remove(bookCopy);
            bookCopy.Reader = null;
        }

        public List<BookInfo> GetAvailableBooks(List<Book> books, List<BookCopy> bookCopies)
        {

            // The best possible solution tbh

            var booksUserHas = (from b in books
                                  from bc in bookCopies
                                  where b.ISBN == bc.ISBN && bc.Reader == this
                                  select b).ToList();

            var booksUserDoesntHave = from b in books
                                      where !booksUserHas.Contains(b)
                                      select b;

            var availableBookCopies = bookCopies.Where(bc => bc.Reader == null);

            // Joins books with their copies
            var almostAvailableBooks = from b in booksUserDoesntHave
                                       join bc in availableBookCopies on b.ISBN equals bc.ISBN into g
                                       select new BookInfo(b, g);

            // To filter books without bookCopies
            var availableBooks = almostAvailableBooks.Where(p => p.BookCopies.ToList().Count != 0).ToList();

                             

            if(availableBooks.Count == 0)
            {
                throw new InvalidOperationException("Bibliotekoje nėra galimų paimti knygų.");
            }

            return availableBooks;
        }

    }

}
