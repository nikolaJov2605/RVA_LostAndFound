using Common;
using Database.ItemCommands;
using Database.ItemCommands.ItemsQueries;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public static class ItemRepository
    {
        public static void ExecuteCommand(ItemDBUpdateCommand command)
        {
            command.Execute();
        }
        public static List<Item> ExecuteQuery(ItemQueries query)
        {
            return query.Execute();
        }
        public static bool ExecuteCheck(ItemCheckings check)
        {
            return check.Execute();
        }
        public static int ModifyItem(ItemGeneration generation)
        {
            return generation.Execute();
        }

        public static Item GetItem(SingleItemQuery query)
        {
            return query.Execute();
        }
    }
}
