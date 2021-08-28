using Common;
using Common.Services;
using Database;
using Database.ItemCommands;
using Database.ItemCommands.ItemsCheckings;
using Database.ItemCommands.ItemsUpdateCommands;
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
            AppDBContext context = new AppDBContext();

            try
            {
                var query = context.Items.Where(x => x.Id == key).First<Item>();
                if (query != null)
                    return query;
            }
            catch
            {
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
