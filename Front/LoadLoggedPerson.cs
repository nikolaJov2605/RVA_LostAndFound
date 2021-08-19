using Common;
using Front.Model;
using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Front
{
    public static class LoadLoggedPerson
    {
        public static PersonModel LoadPerson(string username)
        {
            PersonModel retPerson = new PersonModel();
            Person person = PersonRepository.FindByUsername(username);
            if(person != null)
            {
                retPerson.Username = person.Username;
                retPerson.Name = person.Name;
                retPerson.LastName = person.LastName;

                return retPerson;
            }
            return null;
        }
    }
}
