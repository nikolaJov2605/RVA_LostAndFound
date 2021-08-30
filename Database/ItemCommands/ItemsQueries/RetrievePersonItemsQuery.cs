using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.ItemCommands.ItemsQueries
{
    public class RetrievePersonItemsQuery : ItemQueries
    {
        private Person person;

        public RetrievePersonItemsQuery(Person p)
        {
            person = p;
        }


        public override List<Item> Execute()
        {
            using (AppDBContext context = new AppDBContext())
            {
                return context.Items.Include("Owner").Include("Finder").Where(x => x.Owner.Username == person.Username).ToList();
            }
        }
    }
}
