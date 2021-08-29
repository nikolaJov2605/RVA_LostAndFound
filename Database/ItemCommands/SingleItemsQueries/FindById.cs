using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.ItemCommands.SingleItemsQueries
{
    public class FindById : SingleItemQuery
    {
        private int id;

        public FindById(int identificator)
        {
            id = identificator;
        }

        public override Item Execute()
        {
            using (AppDBContext context = new AppDBContext())
            {
                var query = context.Items.Where(x => x.Id == id).FirstOrDefault<Item>();
                return query;
            }
        }
    }
}
