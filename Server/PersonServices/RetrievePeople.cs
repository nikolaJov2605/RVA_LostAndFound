using Common;
using Common.Services;
using Database;
using Database.PersonCommands;
using Database.PersonCommands.PersonsQueries;
using Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.PersonServices
{
    public class RetrievePeople : IRetrievePeople
    {
        ILoggingManager loggingManager = new LoggingManager();
        public List<Person> LoadPeople()
        {
            PersonQueries query = new RetrieveAllPersons();
            EventLog eventLog = new EventLog(DateTime.Now, Status.INFO, $"EXECUTED LOAD_PEOPLE METHOD: Multiple personns have been loaded from database.");
            loggingManager.LogEvent(eventLog);
            return PersonRepository.ExecuteQuery(query);

        }
    }
}
