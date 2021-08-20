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
            return itemDBContext.Items.ToList();
        }
        public static void AddItem(Item i)
        {
            AppDBContext itemDBContext = new AppDBContext();
            try
            {
                itemDBContext.Items.Add(i);
                itemDBContext.SaveChanges();
            }
            catch (SqlException e)
            {
                Console.Write(e.Message);
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException e)
            {
                Console.WriteLine(e.Message);
            }
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
