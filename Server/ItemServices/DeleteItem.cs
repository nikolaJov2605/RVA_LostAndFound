using Common;
using Common.Services;
using Database;
using Database.ItemCommands;
using Database.ItemCommands.ItemsCheckings;
using Database.ItemCommands.ItemsUpdateCommands;
using Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.ItemServices
{
    public class DeleteItem : IDeleteItem
    {
        ILoggingManager loggingManager = new LoggingManager();
        public Item FindItem(int key)
        {
            AppDBContext context = new AppDBContext();

            try
            {
                var query = context.Items.Include("Owner").Include("Finder").Where(x => x.Id == key).First<Item>();
                if (query != null)
                    return query;
                EventLog eventLog = new EventLog(DateTime.Now, Status.INFO, $"EXECUTED_FIND_ITEM_METHOD: Item {query.Title} found in database");
                loggingManager.LogEvent(eventLog);
            }
            catch
            {
                EventLog eventLog = new EventLog(DateTime.Now, Status.ERROR, $"EXECUTED_FIND_ITEM_METHOD: Item with key {key} couldn't be found in database");
                loggingManager.LogEvent(eventLog);
                return null;
            }
            return null;
        }

        bool IDeleteItem.DeleteItem(int key)
        {
            ItemCheckings check = new KeyExistCheck(key);
            if (ItemRepository.ExecuteCheck(check))
            {
                ItemDBUpdateCommand deleteCommand = new DeleteItemDBCommand(key);
                ItemRepository.ExecuteCommand(deleteCommand);
                EventLog eventLog = new EventLog(DateTime.Now, Status.INFO, $"EXECUTED_DELETE_ITEM_METHOD: Item with key {key} deleted from database.");
                loggingManager.LogEvent(eventLog);
                return true;
            }
            else
            {
                EventLog eventLog = new EventLog(DateTime.Now, Status.INFO, $"EXECUTED_DELETE_ITEM_METHOD: Item with key {key} doesn't exist, and couldn't be deleted from database");
                loggingManager.LogEvent(eventLog);
                return false;
            }
        }
    }
}
