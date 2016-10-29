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
    abstract class User : IEquatable<User>
    {
        public readonly string Name;
        public readonly string PersonalIdentityNumber;
        public readonly string Password;

        public User(string name, string personalIdentityNumber, string password)
        {
            Name = name;
            PersonalIdentityNumber = personalIdentityNumber;
            Password = password;
        }

        public bool Equals(User other)
        {
            return PersonalIdentityNumber.Equals(other.PersonalIdentityNumber);
        }

        override public bool Equals(object other)
        {
            User user = other as User;

            if(user != null)
            {
                return Equals(user);
            }
            else
            {
                return false;
            }

        }

        public override int GetHashCode()
        {
            return PersonalIdentityNumber.GetHashCode();
        }
    }
}
