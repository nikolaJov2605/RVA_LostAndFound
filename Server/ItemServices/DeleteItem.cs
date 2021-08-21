using Common;
using Common.Services;
using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.ItemServices
{
    public class DeleteItem : IDeleteItem
    {
        public Item FindItem(int key)
        {
            throw new NotImplementedException();
        }

        bool IDeleteItem.DeleteItem(Item item)
        {
            if (ItemRepository.Exists(item))
            {
                ItemRepository.DeleteItem(item);
                Console.WriteLine("Item " + item.Title + " successfully deleted from database...");
                return true;
            }
            else
            {
                Console.WriteLine("Item " + item.Title + " doesn't exist and can't be deleted...");
                return false;
            }
        }
    }
}
