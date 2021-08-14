using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Person p = new Person
            {
                Username = "joca",
                Password = "joca",
                Name = "Jovica",
                LastName = "Jovicevic",
                BirthDate = DateTime.Now
             };
            PersonRepository.AddPerson(p);
            Console.WriteLine("\nSve osobe:");
            List<Person> persons = PersonRepository.GetPersons();
            foreach(Person per in persons)
            {
                Console.WriteLine(per.Name + " " + per.LastName);
            }

            Console.ReadLine();
        }
    }
}
