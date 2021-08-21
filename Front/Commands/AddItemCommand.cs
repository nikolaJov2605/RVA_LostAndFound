using Common;
using Common.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Front.Commands
{
    public class AddItemCommand : Command
    {
        private string username;
        private string date;
        private string name;
        private string location;
        private string description;

        private int key;
        private Person owner;

        public AddItemCommand(string username, string date, string name, string location, string description)
        {
            this.username = username;
            this.date = date;
            this.name = name;
            this.location = location;
            this.description = description;
        }

        public override void Execute()
        {
            ChannelFactory<IAddItem> factory = new ChannelFactory<IAddItem>("AddItem");
            IAddItem proxy = factory.CreateChannel();

            key = proxy.GetAvailableKeyValue();
            owner = proxy.FindPerson(username);
            //Person finder = proxy.FindPerson(tbPronalazac.Text);
            Item item = new Item(key, date, name, location, description, owner, null, false);

            proxy.Add(item);
        }


        public override void Unexecute()
        {
            ChannelFactory<IDeleteItem> factory = new ChannelFactory<IDeleteItem>("DeleteItem");
            IDeleteItem proxy = factory.CreateChannel();
            Item item = proxy.FindItem(key);
            if (item != null)
            {
                proxy.DeleteItem(item);
                Console.WriteLine("AddItem Unexecute method done...");
            }
            else
            {
                Console.WriteLine("AddItem Unexecute method failed...");
                return;
            }
        }
    }
}
