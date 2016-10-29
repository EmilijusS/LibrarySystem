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
    class ReaderMenu
    {
        private Reader _reader;
        private List<Book> _books;
        private List<BookCopy> _bookCopies;

        public ReaderMenu(Reader reader, List<Book> books, List<BookCopy> bookCopies)
        {
            _reader = reader;
            _books = books;
            _bookCopies = bookCopies;
        }

        public void Main()
        {
            int choice;

            do
            {
                Console.Clear();
                Console.WriteLine($"Skaitytojas: {_reader.Name}\n");

                Console.WriteLine("1. Pasiimti knygą");
                Console.WriteLine("2. Atiduoti knygą");
                Console.WriteLine("3. Atsijungti");

                choice = UserInput.ReadChoice(3);
                switch (choice)
                {
                    case 1:
                        TakeBook();
                        break;
                    case 2:
                        ReturnBook();
                        break;
                }
            }
            while (choice != 3);
        }

        private void TakeBook()
        {
            List<BookInfo> availableBooks;
            int choice;

            Console.Clear();

            try
            {
                availableBooks = _reader.GetAvailableBooks(_books, _bookCopies);
            }
            catch(InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
                UserInput.EnterToContinue();
                return;
            }

            availableBooks = SortAvailableBooks(availableBooks);

            Console.WriteLine("Knygų sąrašas:");

            int i = 1;

            foreach (var b in availableBooks)
            {
                Console.WriteLine($"{i++}. {b.Book.Author} - {b.Book.Title}, {b.Book.ReleaseYear.Year}. Žanrai: {b.Book.Genre.ToString()}");
            }

            choice = UserInput.ReadChoice(availableBooks.Count);

            try
            {
                _reader.TakeBook(availableBooks[choice - 1].BookCopies.First());
            }
            catch(InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
                UserInput.EnterToContinue();
                return;
            }

            Console.WriteLine($"Knyga \"{availableBooks[choice - 1].Book.Title}\" paimta sėkmingai!");
            UserInput.EnterToContinue();
        }

        private List <BookInfo> SortAvailableBooks(List <BookInfo> availableBooks)
        {
            int choice;

            Console.WriteLine("Pasirinkite, pagal ką išrikiuoti knygų sąrašą:");
            Console.WriteLine("1. Pagal išleidimo datą");
            Console.WriteLine("2. Pagal pavadinimą");

            choice = UserInput.ReadChoice(2);

            switch (choice)
            {
                case 1:
                    availableBooks = availableBooks.OrderBy(b => b.Book.ReleaseYear).ToList();
                    break;
                case 2:
                    availableBooks = availableBooks.OrderBy(b => b.Book.Title).ToList();
                    break;
            }

            return availableBooks;
        }

        private void ReturnBook()
        {
            int choice;

            Console.Clear();

            if(_reader.BooksTaken.Count == 0)
            {
                Console.WriteLine("Jūs neturite pasiėmęs nei vienos knygos.");
                UserInput.EnterToContinue();
                return;
            }

            Console.WriteLine("Jūsų knygų sąrašas:");

            int i = 1;
            Book book;
            foreach (var bc in _reader.BooksTaken)
            {
                book = _books.Where(b => b.ISBN == bc.ISBN).First();

                Console.WriteLine($"{i++}. \"{book.Title}\" grąžinti iki {bc.ReturnDate.ToShortDateString()}");
            }

            Console.WriteLine("Įveskite numerį knygos, kurią norite grąžinti: ");
            choice = UserInput.ReadChoice(_reader.BooksTaken.Count);

            _reader.ReturnBook(_reader.BooksTaken[choice - 1]);

            Console.WriteLine("Knyga grąžinta sėkmingai!");
            UserInput.EnterToContinue();

        }
    }
}
