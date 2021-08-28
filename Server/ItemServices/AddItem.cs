using Common;
using Common.Services;
using Database;
using Database.ItemCommands;
using Database.ItemCommands.ItemsCheckings;
using Database.ItemCommands.ItemsGenerateCommands;
using Database.ItemCommands.ItemsUpdateCommands;
using Database.PersonCommands.SinglePersonsQueries;
using Database.PersonsCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.ItemServices
{
    public class AddItem : IAddItem
    {
        public bool Add(Item item)
        {
            ItemDBUpdateCommand addItem = new AddItemCommand(item);
            ItemRepository.ExecuteCommand(addItem);
            Console.WriteLine("Item " + item.Title + " added to database");
            return true;
        }


        public Person FindPerson(string username)
        {
            SinglePersonQuery personQuery = new FindByUsernameQuery(username);
            Person person = PersonRepository.ExecuteQuery(personQuery);
            if(person != null)
            {
                Console.WriteLine("Person " + username + " found in database");
                return person;
            }
            else
            {
                Console.WriteLine("Person " + username + " does not exist in database");
                return null;
            }
        }

        public int GetAvailableCommandID()
        {
            ItemGeneration commandIDGeneration = new GenerateCommandID();
            int keyVal = ItemRepository.ModifyItem(commandIDGeneration);
            return keyVal;
        }

        public bool UnAdd(int commandID)
        {
            ItemCheckings commandIdCheck = new CommandIDExistCheck(commandID);
            if (ItemRepository.ExecuteCheck(commandIdCheck))
            {
                ItemDBUpdateCommand deleteByCommandID = new DeleteItemByCommandID(commandID);
                ItemRepository.ExecuteCommand(deleteByCommandID);
                Console.WriteLine("Item successfully deleted from database...");
                return true;
            }
            else
            {
                Console.WriteLine("Item doesn't exist and can't be deleted...");
                return false;
            }
        }
    }
}
