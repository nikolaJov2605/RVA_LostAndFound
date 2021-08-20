using Common;
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
        public static List<Item> GetItems()
        {
            AppDBContext itemDBContext = new AppDBContext();
            var query = itemDBContext.Items.Include("Owner").Include("Finder").ToList();
            return query;
        }
        public static void AddItem(Item i)
        {
            AppDBContext appDBContext = new AppDBContext();

            var dataPerson = appDBContext.Persons.FirstOrDefault(x => x.Username == i.Owner.Username);
            var key = appDBContext.Items.Count();
            appDBContext.Items.Add(new Item
            {
                Id = key,
                Date = i.Date,
                Title = i.Title,
                Location = i.Location,
                Description = i.Description,
                Owner = dataPerson,
                Finder = null,
                IsFound = false
            });

            appDBContext.SaveChanges();
        }

        public static bool Exists(Item i)
        {
            AppDBContext context = new AppDBContext();

            try
            {
                var query = context.Items.Where(x => x.Id == i.Id).First<Item>();
                if (query != null)
                    return true;
            }
            catch
            {
                return false;
            }
            return false;
        }

        public static int RowNum()
        {
            AppDBContext context = new AppDBContext();

            int rowNum = context.Items.Count();

            return rowNum;
        }

    }
}
