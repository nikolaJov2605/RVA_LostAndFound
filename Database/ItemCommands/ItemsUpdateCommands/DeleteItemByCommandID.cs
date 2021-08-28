using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.ItemCommands.ItemsUpdateCommands
{
    public class DeleteItemByCommandID : ItemDBUpdateCommand
    {
        private int commandID;

        public DeleteItemByCommandID(int id)
        {
            commandID = id;
        }

        public override void Execute()
        {
            using(AppDBContext appDBContext = new AppDBContext())
            {
                var query = appDBContext.Items.Where(x => x.ItemCommandID == commandID).First<Item>();
                appDBContext.Items.Remove(query);
                appDBContext.SaveChanges();
            }
        }
    }
}
