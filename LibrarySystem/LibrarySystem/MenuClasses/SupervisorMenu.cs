/* 
  Kurso "Taikomasis objektinis programavimas" (VU MIF, PS) 2016/17 m.m. rudens sem.
  1-as laboratorinis darbas "Bibliotekos sistema"
  Darbą atliko: Emilijus Stankus
*/

using LibrarySystem.ValidationClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibrarySystem
{
    class SupervisorMenu
    {
        private LibraryData _libraryData;

        public SupervisorMenu(LibraryData libraryData)
        {
            _libraryData = libraryData;
        }

        public void Main()
        {
            int choice;

            do
            {
                Console.Clear();
                Console.WriteLine($"Administratorius: {_libraryData.Supervisor.Name}\n");

                Console.WriteLine("1. Pridėti knygą");
                Console.WriteLine("2. Pridėti egzempliorių");
                Console.WriteLine("3. Išspausdinti vartotojų ir jų knygų sąrašą");
                Console.WriteLine("4. Atsijungti");

                choice = UserInput.ReadChoice(4);

                switch (choice)
                {
                    case 1:
                        AddBook();
                        break;
                    case 2:
                        AddBookCopy();
                        break;
                    case 3:
                        PrintReaders();
                        break;
                }
            }
            while (choice != 4);
                             
        }

        private void AddBook()
        {
            string title, author, ISBN, menuTitle = "NAUJA KNYGA";
            DateTime releaseYear;
            Genres genre;
            Book toAdd;

            title = UserInput.ReadInfo(new TitleValidation(), menuTitle);

            author = UserInput.ReadInfo(new AuthorValidation(), menuTitle);

            ISBN = UserInput.ReadInfo(new ISBNValidation(), menuTitle);

            releaseYear = new DateTime(int.Parse(UserInput.ReadInfo(new YearValidation(), menuTitle)), 1, 1);

            genre = ChooseGenre();

            toAdd = new Book(title, author, ISBN, releaseYear, genre);

            if (_libraryData.Books.Contains(toAdd))
            {
                Console.Write("Tokia knyga jau yra sistemoje.");
            }
            else
            {
                _libraryData.Books.Add(toAdd);
                Console.Write("Knyga sėkmingai pridėta.");
            }

            UserInput.EnterToContinue();
        }

        private Genres ChooseGenre()
        {
            string input;
            IValidator infoType = new GenreValidation();
            Genres genre = new Genres();

            Console.Clear();
            Console.WriteLine("Žanrai:");
            Console.WriteLine($"1. {Genres.Fantastika.ToString()}");
            Console.WriteLine($"2. {Genres.Drama.ToString()}");
            Console.WriteLine($"3. {Genres.Detektyvas.ToString()}");
            Console.WriteLine($"4. {Genres.Siaubo.ToString()}");
            Console.WriteLine($"5. {Genres.Veiksmo.ToString()}");
            Console.WriteLine($"6. {Genres.Nuotykių.ToString()}");
            Console.WriteLine($"7. {Genres.Romantinė.ToString()}");
            Console.WriteLine($"8. {Genres.Komedija.ToString()}");
            Console.WriteLine($"9. {Genres.Poezija.ToString()}");
            Console.WriteLine(infoType.Message);

            do
            {
                input = Console.ReadLine();

                if (!infoType.IsValid(input))
                {
                    Console.WriteLine(infoType.ErrorMessage);
                }

            }
            while (!infoType.IsValid(input));

            // Hope this works
            for (int i = 0; i < input.Length; ++i)
            {
                genre += (int)Math.Pow(2, (input[i] - '0' - 1));
            }

            return genre;
        }

        private void AddBookCopy()
        {
            int i = 1, choice = 0;

            Console.Clear();

            if (_libraryData.Books.Count == 0)
            {
                Console.Write("Sistemoje nėra nei vienos knygos.");
                UserInput.EnterToContinue();
                return;
            }

            Console.WriteLine("Knygų sąrašas:");

            foreach (Book book in _libraryData.Books)
            {
                Console.WriteLine($"{i++}. {book.Author} - {book.Title}");
            }

            Console.WriteLine("Įveskite numerį knygos, kurios egzempliorių norite pridėti: ");
            choice = UserInput.ReadChoice(_libraryData.Books.Count);

            _libraryData.BookCopies.Add(new BookCopy(_libraryData.Books[choice - 1].ISBN));
            Console.Write("Knygos egzempliorius pridėtas sėkmingai. ");
            UserInput.EnterToContinue();

        }

        private void PrintReaders()
        {
            int counter = 1;

            IEnumerable<LibraryInfo> result = _libraryData.Supervisor.GetLibraryInfo();

            Console.Clear();

            foreach (var i in result)
            {
                Console.WriteLine($"{counter++}. {i.ReaderName}:");

                foreach (var j in i.ReaderInfo)
                {
                    Console.WriteLine($"{j.BookTitle}, grąžinti iki {j.BookReturnDate}");
                }
            }

            UserInput.EnterToContinue();
        }
    }
}
