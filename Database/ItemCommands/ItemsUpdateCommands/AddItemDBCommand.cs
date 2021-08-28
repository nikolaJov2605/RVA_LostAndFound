using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.ItemCommands.ItemsUpdateCommands
{
    public class AddItemCommand : ItemDBUpdateCommand
    {
        private Item item;

        public AddItemCommand(Item i)
        {
            item = i;
        }


        public override void Execute()
        {
            using (AppDBContext appDBContext = new AppDBContext())
            {
                var dataPerson = appDBContext.Persons.FirstOrDefault(x => x.Username == item.Owner.Username);
                Item toAdd = item;
                toAdd.Owner = dataPerson;

                appDBContext.Items.Add(toAdd);

                appDBContext.SaveChanges();
            }
        }
    }
}
