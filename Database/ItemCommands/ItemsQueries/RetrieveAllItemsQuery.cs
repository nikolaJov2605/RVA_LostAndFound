using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.ItemCommands.ItemsQueries
{
    public class RetrieveAllItemsQuery : ItemQueries
    {
        public override List<Item> Execute()
        {
            using (AppDBContext itemDBContext = new AppDBContext())
            {
                var query = itemDBContext.Items.Include("Owner").Include("Finder").ToList();
                return query;
            }
        }
    }
}
