using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.ItemCommands.ItemsUpdateCommands
{
    public class UndoItemFoundCommand : ItemDBUpdateCommand
    {
        private int key;

        public UndoItemFoundCommand(int id)
        {
            key = id;
        }

        public override void Execute()
        {
            using (AppDBContext context = new AppDBContext())
            {
                var query = context.Items.Include("Owner").Include("Finder").Where(x => x.Id == key).FirstOrDefault<Item>();
                query.IsFound = false;
                query.Finder = null;

                context.SaveChanges();
            }
        }
    }
}
