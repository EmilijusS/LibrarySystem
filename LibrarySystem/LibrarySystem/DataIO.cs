/* 
  Kurso "Taikomasis objektinis programavimas" (VU MIF, PS) 2016/17 m.m. rudens sem.
  1-as laboratorinis darbas "Bibliotekos sistema"
  Darbą atliko: Emilijus Stankus
*/

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem
{
    static class DataIO
    {
        // Initializes data from files
        public static LibraryData Read()
        {
            IFormatter formatter = new BinaryFormatter();
            Supervisor supervisor;
            List<Reader> readers;
            List<Book> books;
            List<BookCopy> bookCopies; 

            using (Stream stream = new FileStream("Data/Supervisor.txt", FileMode.Open, FileAccess.Read))
            {
                supervisor = (Supervisor)formatter.Deserialize(stream);
            }

            using (Stream stream = new FileStream("Data/Readers.txt", FileMode.Open, FileAccess.Read))
            {
                readers = (List<Reader>)formatter.Deserialize(stream);
            }

            using (Stream stream = new FileStream("Data/Books.txt", FileMode.Open, FileAccess.Read))
            {
                books = (List<Book>)formatter.Deserialize(stream);
            }

            using (Stream stream = new FileStream("Data/BookCopies.txt", FileMode.Open, FileAccess.Read))
            {
                bookCopies = (List<BookCopy>)formatter.Deserialize(stream);
            }

            // Because Lists with data have to be added to supervisor object
            supervisor = new Supervisor(name: supervisor.Name, personalIdentityNumber: supervisor.PersonalIdentityNumber, password: supervisor.Password, readerListP: readers,
                bookListP: books, bookCopyListP: bookCopies);

            return new LibraryData(supervisor, readers, books, bookCopies);
        }

        //Stores all the data into files
        public static void Write(LibraryData libraryData)
        {
            IFormatter formatter = new BinaryFormatter();

            using (Stream stream = new FileStream("Data/Supervisor.txt", FileMode.Open, FileAccess.Write))
            {
                formatter.Serialize(stream, libraryData.Supervisor);
            }

            using (Stream stream = new FileStream("Data/Readers.txt", FileMode.Open, FileAccess.Write))
            {
                formatter.Serialize(stream, libraryData.Readers);
            }

            using (Stream stream = new FileStream("Data/Books.txt", FileMode.Open, FileAccess.Write))
            {
                formatter.Serialize(stream, libraryData.Books);
            }

            using (Stream stream = new FileStream("Data/BookCopies.txt", FileMode.Open, FileAccess.Write))
            {
                formatter.Serialize(stream, libraryData.BookCopies);
            }
        }
    }
}
