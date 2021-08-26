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
    public class RetrieveItems : IRetrieveItems
    {
        public List<Item> RetrieveAllItems()
        {
            using (AppDBContext context = new AppDBContext())
            {
                return context.Items.ToList();
            }
        }
    }
}
