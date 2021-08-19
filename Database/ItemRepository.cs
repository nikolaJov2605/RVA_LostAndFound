using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public static class ItemRepository
    {
        public static List<Item> GetItems()
        {
            AppDBContext itemDBContext = new AppDBContext();
            return itemDBContext.Items.ToList();
        }
    }
}
