using Common.Services;
using Database;
using Database.ItemCommands;
using Database.ItemCommands.ItemsUpdateCommands;
using Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.ItemServices
{
    public class SetItemIsFound : ISetItemIsFound
    {
        ILoggingManager loggingManager = new LoggingManager();
        public void ItemFound(int key, string finderUsername)
        {
            ItemDBUpdateCommand itemFoundCommand = new SetItemFoundCommand(key, finderUsername);
            ItemRepository.ExecuteCommand(itemFoundCommand);

            EventLog eventLog = new EventLog(DateTime.Now, Status.INFO, $"EXECUTED_ITEM_FOUND_METHOD: Item with key {key} has beend marked as found by {finderUsername}.");
            loggingManager.LogEvent(eventLog);
        }

        public void ItemNotFound(int key)
        {
            ItemDBUpdateCommand itemNotFoundCommand = new UndoItemFoundCommand(key);
            ItemRepository.ExecuteCommand(itemNotFoundCommand);

            EventLog eventLog = new EventLog(DateTime.Now, Status.INFO, $"EXECUTED_ITEM_NOT_FOUND_METHOD: Item with key {key} has beend unmarked as found.");
            loggingManager.LogEvent(eventLog);
        }
    }
}
