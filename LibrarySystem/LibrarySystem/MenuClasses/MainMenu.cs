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
    class MainMenu
    {
        private LibraryData _libraryData;

        // Starting main menu
        public void Start()
        {
            int choice;

            _libraryData = DataIO.Read();

            //PURGE ALL DATA
            //_libraryData.Books.Clear();
            //_libraryData.Readers.Clear();
            //_libraryData.BookCopies.Clear();

            // Repeats every time user enters main menu
            do
            {
                Console.Clear();
                Console.WriteLine("Bibliotekos sistema.");
                Console.WriteLine("Meniu naudokitės įrašydami atitinkamo meniu punkto numerį\n");

                Console.WriteLine("1. Prisijungti");
                Console.WriteLine("2. Užsiregistruoti");
                Console.WriteLine("3. Išjungti programą");

                choice = UserInput.ReadChoice(3);

                switch (choice)
                {
                    case 1:
                        Login();
                        break;
                    case 2:
                        Register();
                        break;
                }

            }
            while (choice != 3);

            DataIO.Write(_libraryData);
        }

        private void Register()
        {
            string name, personalIdentityNumber, password, title = "REGISTRACIJA";
            Reader toAdd;

            personalIdentityNumber = UserInput.ReadInfo(new PersonalIdentityNumberValidation(), title);

            name = UserInput.ReadInfo(new NameValidation(), title);

            password = UserInput.ReadPassword(new PasswordValidation(), title).Encrypt();

            toAdd = new Reader(name: name, personalIdentityNumber: personalIdentityNumber, password: password);

            if (_libraryData.Readers.Contains(toAdd))
            {
                Console.WriteLine("Registracija nesėkminga, nes jūs jau esate prisiregistravęs.");
                UserInput.EnterToContinue();
            }
            else
            {
                _libraryData.Readers.Add(toAdd);
                Console.WriteLine("Registracija sėkminga.");
                UserInput.EnterToContinue();
            }

        }

        private void Login()
        {
            string personalIdentityNumber, password, title = "PRISIJUNGIMAS";
            User user;

            personalIdentityNumber = UserInput.ReadInfo(new PersonalIdentityNumberValidation(), title);

            var search = _libraryData.Readers.Where(r => r.PersonalIdentityNumber == personalIdentityNumber);

            if (_libraryData.Supervisor.PersonalIdentityNumber == personalIdentityNumber)
            {
                user = _libraryData.Supervisor;
            }
            else if (search.ToList().Count != 0)
            {
                user = search.ToList()[0];
            }
            else
            {
                Console.Write("Vartotojas nerastas.");
                UserInput.EnterToContinue();
                return;
            }

            password = UserInput.ReadPassword(new PasswordValidation(), title).Encrypt();

            if (password == user.Password)
            {
                if (user.Equals(_libraryData.Supervisor))
                {
                    new SupervisorMenu(_libraryData).Main();
                }
                else
                {
                    new ReaderMenu((Reader)user, _libraryData.Books, _libraryData.BookCopies).Main();
                }
            }
            else
            {
                Console.Write("Neteisingas slaptažodis.");
                UserInput.EnterToContinue();
            }
        }
    }
}
