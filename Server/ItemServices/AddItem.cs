using Common;
using Common.Services;
using Database;
using Database.ItemCommands;
using Database.ItemCommands.ItemsCheckings;
using Database.ItemCommands.ItemsGenerateCommands;
using Database.ItemCommands.ItemsUpdateCommands;
using Database.PersonCommands.SinglePersonsQueries;
using Database.PersonsCommands;
using Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.ItemServices
{
    public class AddItem : IAddItem
    {
        ILoggingManager loggingManager = new LoggingManager();
        public bool Add(Item item)
        {
            ItemDBUpdateCommand addItem = new AddItemCommand(item);
            ItemRepository.ExecuteCommand(addItem);

            EventLog eventLog = new EventLog(DateTime.Now, Status.INFO, $"EXECUTED_ADD_ITEM_METHOD: Item {item.Title} has been added to database");
            loggingManager.LogEvent(eventLog);

            return true;
        }

        public void AddMulitpleItems(List<Item> items)
        {
            foreach (Item item in items)
            {
                ItemDBUpdateCommand addItem = new AddItemCommand(item);
                ItemRepository.ExecuteCommand(addItem);
            }
            EventLog eventLog = new EventLog(DateTime.Now, Status.INFO, "EXECUTED_ADD_MULTIPLE_ITEMS_METHOD: Several items have been added to database");
            loggingManager.LogEvent(eventLog);
        }

        public Person FindPerson(string username)
        {
            SinglePersonQuery personQuery = new FindByUsernameQuery(username);
            Person person = PersonRepository.ExecuteQuery(personQuery);
            if(person != null)
            {
                EventLog eventLog = new EventLog(DateTime.Now, Status.INFO, $"EXECUTED_FIND_PERSON_METHOD: Person {username} found in database");
                loggingManager.LogEvent(eventLog);
                return person;
            }
            else
            {
                EventLog eventLog = new EventLog(DateTime.Now, Status.ERROR, $"EXECUTED_FIND_PERSON_METHOD: Couldn't find person {username} in database");
                loggingManager.LogEvent(eventLog);
                return null;
            }
        }

        public int GetAvailableCommandID()
        {
            ItemGeneration commandIDGeneration = new GenerateCommandID();
            int keyVal = ItemRepository.ModifyItem(commandIDGeneration);

            EventLog eventDebugLog = new EventLog(DateTime.Now, Status.DEBUG, $"EXECUTED_GET_AVAILABLE_COMMAND_ID: Generated commandID value is {keyVal}");
            EventLog eventLog = new EventLog(DateTime.Now, Status.INFO, "EXECUTED_GET_AVAILABLE_COMMAND_ID: commandID is generated");
            loggingManager.LogEvent(eventDebugLog);
            loggingManager.LogEvent(eventLog);
            return keyVal;
        }

        public bool UnAdd(int commandID)
        {
            ItemCheckings commandIdCheck = new CommandIDExistCheck(commandID);
            if (ItemRepository.ExecuteCheck(commandIdCheck))
            {
                ItemDBUpdateCommand deleteByCommandID = new DeleteItemByCommandID(commandID);
                ItemRepository.ExecuteCommand(deleteByCommandID);
                EventLog eventLog = new EventLog(DateTime.Now, Status.INFO, $"EXECUTED_UN_ADD_COMMAND_ID: Item with commandID: {commandID} successfully removed from database");
                loggingManager.LogEvent(eventLog);
                return true;
            }
            else
            {
                EventLog eventLog = new EventLog(DateTime.Now, Status.ERROR, $"EXECUTED_UN_ADD_COMMAND_ID: Couldn't find item with commandID: {commandID}");
                loggingManager.LogEvent(eventLog);
                return false;
            }
        }
    }
}
