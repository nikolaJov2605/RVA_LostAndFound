using Common;
using Common.Services;
using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.AddItem
{
    public class AddItem : IAddItem
    {
        public bool Add(Item item)
        {
            if (ItemRepository.Exists(item))
            {
                Console.WriteLine("Item " + item.Title + " failed to be added to database");
                return false;
            }
            else
            {
                ItemRepository.AddItem(item);
                Console.WriteLine("Item " + item.Title + " added to database");
                return true;
            }
        }


        public Person FindPerson(string username)
        {
            Person person = PersonRepository.FindByUsername(username);
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

        public int GetAvailableKeyValue()
        {
            int keyVal = ItemRepository.RowNum();
            Console.WriteLine("Key declared to item is " + keyVal.ToString());
            return keyVal;
        }
    }
}
