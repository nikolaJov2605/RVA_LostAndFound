using Common;
using Common.Services;
using Database;
using Database.ItemCommands;
using Database.ItemCommands.ItemsQueries;
using Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.PersonServices
{
    public class RetrievePersonItems : IRetrievePersonItems
    {
        ILoggingManager loggingManager = new LoggingManager();
        public List<Item> GetPersonItems(Person person)
        {
            ItemQueries query = new RetrievePersonItemsQuery(person);


            EventLog eventLog = new EventLog(DateTime.Now, Status.INFO, $"EXECUTED GET_PERSON_ITEMS METHOD: Loaded person items from person {person.Username}");
            loggingManager.LogEvent(eventLog);

            return ItemRepository.ExecuteQuery(query);

        }
    }
}
