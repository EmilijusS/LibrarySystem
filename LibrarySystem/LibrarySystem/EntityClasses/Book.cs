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
    class Book : IEquatable<Book>
    {
        public readonly string Title;
        public readonly string Author;
        public readonly string ISBN;
        public readonly DateTime ReleaseYear;
        public readonly Genres Genre;

        public Book(string title, string author, string paramISBN, DateTime releaseYear, Genres genre)
        {
            Title = title;
            Author = author;
            ISBN = paramISBN;
            ReleaseYear = releaseYear;
            Genre = genre;
        }

        public bool Equals(Book other)
        {
            return this.ISBN.Equals(other.ISBN);
        }

        override public bool Equals(object other)
        {
            Book book = other as Book;

            if (book != null)
            {
                return Equals(book);
            }
            else
            {
                return false;
            }

        }

        public override int GetHashCode()
        {
            return ISBN.GetHashCode();
        }
    }
}
