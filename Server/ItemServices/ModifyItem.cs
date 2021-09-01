using Common;
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
    public class ModifyItem : IModifyItem
    {
        ILoggingManager loggingManager = new LoggingManager();
        void IModifyItem.ModifyItem(Item toModify, Item modified)
        {
            ItemDBUpdateCommand modifyItemCommand = new ModifyItemDBCommand(toModify, modified);
            ItemRepository.ExecuteCommand(modifyItemCommand);

            EventLog eventLog = new EventLog(DateTime.Now, Status.INFO, $"EXECUTED_MODIFY_ITEM_METHOD: Item {toModify.Title} has been modified. New item title is {modified.Title}.");
            loggingManager.LogEvent(eventLog);
        }
    }
}
