using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public static class PersonRepository
    {
        public static List<Person> GetPersons()
        {
            AppDBContext personDBContext = new AppDBContext();
            return personDBContext.Persons.ToList();
        }

        public static void AddPerson(Person p)
        {
            AppDBContext personDBContext = new AppDBContext();
            try
            {
                personDBContext.Persons.Add(p);
                personDBContext.SaveChanges();
            }
            catch(SqlException e)
            {
                Console.Write(e.Message);
            }
            catch(System.Data.Entity.Infrastructure.DbUpdateException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
