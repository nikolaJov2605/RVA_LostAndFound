using Common;
using Common.Services;
using Database;
using Database.PersonCommands;
using Database.PersonCommands.PersonsQueries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.PersonServices
{
    public class RetrievePeople : IRetrievePeople
    {
        public List<Person> LoadPeople()
        {
            PersonQueries query = new RetrieveAllPersons();
            return PersonRepository.ExecuteQuery(query);
        }
    }
}
