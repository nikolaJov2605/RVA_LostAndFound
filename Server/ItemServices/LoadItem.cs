using Common;
using Common.Services;
using Database;
using Database.ItemCommands;
using Database.ItemCommands.SingleItemsQueries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.ItemServices
{
    public class LoadItem : ILoadItem
    {
        public Item Load(int id)
        {
            SingleItemQuery getItem = new FindById(id);
            return ItemRepository.GetItem(getItem);
        }
    }
}
