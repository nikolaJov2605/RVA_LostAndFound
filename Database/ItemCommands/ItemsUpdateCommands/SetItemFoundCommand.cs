using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.ItemCommands.ItemsUpdateCommands
{
    public class SetItemFoundCommand : ItemDBUpdateCommand
    {
        private int key;
        private string finderUsr;

        public SetItemFoundCommand(int id, string finderUsername)
        {
            key = id;
            finderUsr = finderUsername;
        }

        public override void Execute()
        {
            using (AppDBContext context = new AppDBContext())
            {
                var finder = context.Persons.Where(x => x.Username == finderUsr).FirstOrDefault<Person>();

                var query = context.Items.Include("Owner").Include("Finder").Where(x => x.Id == key).FirstOrDefault<Item>();
                query.IsFound = true;
                query.Finder = finder;

                context.SaveChanges();
            }
        }
    }
}
