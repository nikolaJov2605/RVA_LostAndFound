using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.ItemCommands.ItemsUpdateCommands
{
    public class ModifyItemDBCommand : ItemDBUpdateCommand
    {
        private Item toModify;
        private Item modified;

        public ModifyItemDBCommand(Item oldItem, Item newItem)
        {
            toModify = oldItem;
            modified = newItem;
        }

        public override void Execute()
        {
            Item item = new Item();
            using (AppDBContext context = new AppDBContext())
            {
                var query = context.Items.Where(x => x.Id == toModify.Id).FirstOrDefault<Item>();

                query.Id = modified.Id;
                query.Date = modified.Date;
                query.Title = modified.Title;
                query.Location = modified.Location;
                query.Description = modified.Description;
                query.Finder = modified.Finder;
                query.IsFound = modified.IsFound;


                context.SaveChanges();

            }
        }
    }
}
