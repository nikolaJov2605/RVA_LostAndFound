using Common;
using Common.Services;
using Database;
using Database.ItemCommands;
using Database.ItemCommands.SingleItemsQueries;
using Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.ItemServices
{
    public class LoadItem : ILoadItem
    {
        ILoggingManager loggingManager = new LoggingManager();
        public Item Load(int id)
        {
            SingleItemQuery getItem = new FindById(id);

            EventLog eventLog = new EventLog(DateTime.Now, Status.INFO, $"EXECUTED_LOAD_ITEM_METHOD: Item with key {id} loaded from database.");
            loggingManager.LogEvent(eventLog);
            return ItemRepository.GetItem(getItem);
        }
    }
}
