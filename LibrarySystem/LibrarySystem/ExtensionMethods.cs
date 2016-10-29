/* 
  Kurso "Taikomasis objektinis programavimas" (VU MIF, PS) 2016/17 m.m. rudens sem.
  1-as laboratorinis darbas "Bibliotekos sistema"
  Darbą atliko: Emilijus Stankus
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem
{
    public static class ExtensionMethods
    {
        public static string Encrypt(this String str)
        {
            HashAlgorithm sha = SHA256.Create();
            return Convert.ToBase64String(sha.ComputeHash(Encoding.Default.GetBytes(str)));
        }
    }
}
