using Common;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.PersonCommands.PersonUpdateCommands
{
    public class AddPersonDBCommand : PersonDBUpdateCommand
    {
        private Person person;

        public AddPersonDBCommand(Person p)
        {
            person = p;
        }

        public override void Execute()
        {
            AppDBContext personDBContext = new AppDBContext();
            try
            {
                personDBContext.Persons.Add(person);
                personDBContext.SaveChanges();
            }
            catch (SqlException e)
            {
                Console.Write(e.Message);
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
