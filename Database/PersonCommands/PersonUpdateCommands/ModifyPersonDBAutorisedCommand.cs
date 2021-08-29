using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.PersonCommands.PersonUpdateCommands
{
    public class ModifyPersonDBAutorisedCommand : PersonDBUpdateCommand
    {
        private Person person;

        public ModifyPersonDBAutorisedCommand(Person p)
        {
            person = p;
        }

        public override void Execute()
        {
            using (AppDBContext context = new AppDBContext())
            {
                var query = context.Persons.Where(x => x.Username == person.Username).SingleOrDefault<Person>();

                query.Password = person.Password;
                query.Name = person.Name;
                query.LastName = person.LastName;
                query.Role = person.Role;
                query.BirthDate = person.BirthDate;

                context.SaveChanges();
            }
        }
    }
}
