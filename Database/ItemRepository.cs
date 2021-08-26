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
            using (AppDBContext itemDBContext = new AppDBContext())
            {
                var query = itemDBContext.Items.Include("Owner").Include("Finder").ToList();
                return query;
            }
        }
        public static void AddItem(Item i)
        {
            using (AppDBContext appDBContext = new AppDBContext())
            {
                var dataPerson = appDBContext.Persons.FirstOrDefault(x => x.Username == i.Owner.Username);
                //var key = appDBContext.Items.Count();
                //Item toAdd = new Item(i.Id, i.Date, i.Title, i.Location, i.Description, dataPerson, false);
                Item toAdd = i;
                toAdd.Owner = dataPerson;

                appDBContext.Items.Add(toAdd);

                appDBContext.SaveChanges();
            }

        }

        public static void DeleteItem(int key)
        {
            using (AppDBContext appDBContext = new AppDBContext())
            {
                var query = appDBContext.Items.Where(x => x.Id == key).First<Item>();
                appDBContext.Items.Remove(query);
                appDBContext.SaveChanges();
            }
        }

        public static bool Exists(int key)
        {
            AppDBContext context = new AppDBContext();

            try
            {
                var query = context.Items.Where(x => x.Id == key).First<Item>();
                if (query != null)
                    return true;
            }
            catch
            {
                return false;
            }
            return false;
        }

        public static int GenerateCommandID()
        {
            using (AppDBContext context = new AppDBContext())
            {
                int id;
                /*if (context.Items.Count<Item>() == 0)
                    rownum = 0;
                else
                    rownum = context.Items.Max(x=>x.Id);*/

                id = (int)DateTime.Now.ToUniversalTime().Subtract(new DateTime(2020, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds;

                return id;
            }
        }

        public static bool ExistsCommandID(int commandID)
        {
            AppDBContext context = new AppDBContext();

            try
            {
                var query = context.Items.Where(x => x.ItemCommandID == commandID).First<Item>();
                if (query != null)
                    return true;
            }
            catch
            {
                return false;
            }
            return false;
        }

        public static void DeleteByCommandID(int commandID)
        {
            using (AppDBContext appDBContext = new AppDBContext())
            {
                var query = appDBContext.Items.Where(x => x.ItemCommandID == commandID).First<Item>();
                appDBContext.Items.Remove(query);
                appDBContext.SaveChanges();
            }
        }
    }
}
