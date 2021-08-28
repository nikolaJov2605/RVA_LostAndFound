using Common;
using Common.Services;
using Database;
using Database.ItemCommands;
using Database.ItemCommands.ItemsQueries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.ItemServices
{
    public class RetrieveItems : IRetrieveItems
    {
        public List<Item> RetrieveAllItems()
        {
            ItemQueries retrieveAll = new RetrieveAllItemsQuery();
            return ItemRepository.ExecuteQuery(retrieveAll);
        }
    }
}
