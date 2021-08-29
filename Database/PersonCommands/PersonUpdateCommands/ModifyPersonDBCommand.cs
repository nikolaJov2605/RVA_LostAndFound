using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.PersonCommands.PersonUpdateCommands
{
    public class ModifyPersonDBCommand : PersonDBUpdateCommand
    {
        private Person person;

        public ModifyPersonDBCommand(Person p)
        {
            person = p;
        }

        public override void Execute()
        {
            using (AppDBContext appDBContext = new AppDBContext())
            {
                var query = appDBContext.Persons.Where(x => x.Username == person.Username).FirstOrDefault();

                query.Name = person.Name;
                query.LastName = person.LastName;

                appDBContext.SaveChanges();
            }
        }
    }
}
