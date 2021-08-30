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

namespace Server.PersonServices
{
    public class RetrievePersonItems : IRetrievePersonItems
    {
        public List<Item> GetPersonItems(Person person)
        {
            ItemQueries query = new RetrievePersonItemsQuery(person);
            return ItemRepository.ExecuteQuery(query);

        }
    }
}
