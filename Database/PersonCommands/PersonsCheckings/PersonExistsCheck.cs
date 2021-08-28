using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.PersonCommands.PersonsCheckings
{
    public class PersonExistsCheck : PersonCheckings
    {
        private Person person;

        public PersonExistsCheck(Person p)
        {
            person = p;
        }

        public override bool Execute()
        {
            AppDBContext context = new AppDBContext();

            try
            {
                var query = context.Persons.Where(x => x.Username == person.Username).First<Person>();
                if (query != null)
                    return true;
            }
            catch
            {
                return false;
            }

            return false;
        }
    }
}
