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

namespace Server.ItemServices
{
    public class RetrieveItems : IRetrieveItems
    {
        ILoggingManager loggingManager = new LoggingManager();
        public List<Item> RetrieveAllItems()
        {
            ItemQueries retrieveAll = new RetrieveAllItemsQuery();

            EventLog eventLog = new EventLog(DateTime.Now, Status.INFO, $"EXECUTED_RETRIEVE_ALL_ITEMS_METHOD: Items have been successfully loaded from database.");
            loggingManager.LogEvent(eventLog);

            return ItemRepository.ExecuteQuery(retrieveAll);
        }
    }
}
