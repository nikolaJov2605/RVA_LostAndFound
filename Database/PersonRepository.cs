using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace Database
{
    public static class PersonRepository
    {
        public static List<Person> GetPersons()
        {
            using (AppDBContext personDBContext = new AppDBContext())
            {
                return personDBContext.Persons.ToList();
            }
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

        public static bool Exists(Person p)
        {

            AppDBContext context = new AppDBContext();

            try
            {
                var query = context.Persons.Where(x => x.Username == p.Username).First<Person>();
                if (query != null)
                    return true;
            }
            catch
            {
                return false;
            }

            return false;
            
        }

        public static Person FindByUsername(string username)
        {
            AppDBContext context = new AppDBContext();

            try
            {
                var query = context.Persons.Where(x => x.Username == username).First<Person>();
                if (query != null)
                    return query;
            }
            catch
            {
                return null;
            }
            return null;
        }
    }
}
