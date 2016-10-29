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
    static class UserInput
    {
        // Used whenever user has to input some information
        public static string ReadInfo(IValidator infoType, string title)
        {
            string input;

            Console.Clear();

            Console.WriteLine(title);
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

            return input;
        }

        // Copied from http://stackoverflow.com/questions/3404421/password-masking-console-application
        // Dedikuota Vytautui Mackoniui
        public static string ReadPassword(IValidator infoType, string title)
        {
            string input;
            ConsoleKeyInfo key;

            Console.Clear();

            Console.WriteLine(title);
            Console.WriteLine(infoType.Message);

            do
            {
                input = "";

                do
                {
                    key = Console.ReadKey(true);

                    // Backspace Should Not Work
                    if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                    {
                        input += key.KeyChar;
                        Console.Write("*");
                    }
                    else
                    {
                        if (key.Key == ConsoleKey.Backspace && input.Length > 0)
                        {
                            input = input.Substring(0, (input.Length - 1));
                            Console.Write("\b \b");
                        }
                    }
                }
                // Stops Receving Keys Once Enter is Pressed
                while (key.Key != ConsoleKey.Enter);

                if (!infoType.IsValid(input))
                {
                    Console.WriteLine($"\n{infoType.ErrorMessage}");
                }
            }
            while (!infoType.IsValid(input));

            // Needed after succesful input
            Console.WriteLine();

            return input;
        }

        public static int ReadChoice(int upperBound)
        {
            int choice;
            string input;

            do
            {
                input = Console.ReadLine();

                if (int.TryParse(input, out choice))
                {
                    if (choice <= 0 || choice > upperBound)
                    {
                        Console.WriteLine("Neteisinga įvestis");
                    }
                }
                else
                {
                    Console.WriteLine("Neteisinga įvestis");
                }
            }
            while (choice <= 0 || choice > upperBound);

            return choice;
        }

        public static void EnterToContinue()
        {
            Console.WriteLine("Spauskite enter norėdami tęsti...");
            Console.ReadLine();
        }
    }
}
