using Common;
using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Front
{
    public class LoadItemsInfo
    {
        public static List<Item> LoadItems()
        {
            return ItemRepository.GetItems();
        }
    }
}
