using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.PersonCommands.PersonsQueries
{
    public class RetrieveAllPersons : PersonQueries
    {
        public override List<Person> Execute()
        {
            using (AppDBContext personDBContext = new AppDBContext())
            {
                return personDBContext.Persons.ToList();
            }
        }
    }
}
