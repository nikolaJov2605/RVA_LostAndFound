using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.ItemCommands.ItemsUpdateCommands
{
    public class DeleteItemDBCommand : ItemDBUpdateCommand
    {
        private int key;

        public DeleteItemDBCommand(int k)
        {
            key = k;
        }


        public override void Execute()
        {
            using (AppDBContext appDBContext = new AppDBContext())
            {
                var query = appDBContext.Items.Where(x => x.Id == key).First<Item>();
                appDBContext.Items.Remove(query);
                appDBContext.SaveChanges();
            }
        }
    }
}
