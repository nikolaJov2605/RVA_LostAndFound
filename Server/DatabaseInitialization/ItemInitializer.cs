using Common;
using Database;
using Logger;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.DatabaseInitialization
{
    public class ItemInitializer : IDatabaseInitializer
    {
        ILoggingManager loggingManager = new LoggingManager();
        public void InitializeTable()
        {
            List<Item> initialItemList = LoadFromFile.LoadItems();

            using (AppDBContext context = new AppDBContext())
            {
                if(context.Items.Count() == 0)
                {
                    foreach (Item item in initialItemList)
                    {
                        context.Items.Add(item);
                    }

                    context.SaveChanges();

                    EventLog eventLog = new EventLog(DateTime.Now, Status.INFO, "All initial items have been loaded to database.");
                    loggingManager.LogEvent(eventLog);
                }
            }
        }
    }
}
