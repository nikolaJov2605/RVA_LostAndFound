using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.PersonCommands.PersonUpdateCommands
{
    public class DeletePersonDBCommand : PersonDBUpdateCommand
    {
        private Person person;

        public DeletePersonDBCommand(Person p)
        {
            person = p;
        }

        public override void Execute()
        {
            using (AppDBContext appDBContext = new AppDBContext())
            {
                // brisanje svih predmeta koju je ta osoba dodala
                List<Item> items = appDBContext.Items.Where(x => x.Owner.Username == person.Username).ToList();
                foreach(Item i in items)
                {
                    appDBContext.Items.Remove(i);
                }

                var query = appDBContext.Persons.Where(x => x.Username == person.Username).First<Person>();
                appDBContext.Persons.Remove(query);
                appDBContext.SaveChanges();
            }
        }
    }
}
