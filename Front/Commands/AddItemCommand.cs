using Common;
using Common.Services;
using Database;
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

        private int commandID;
        private Person owner;

        public AddItemCommand(string username, string date, string name, string location, string description)
        {
            this.username = username;
            this.date = date;
            this.name = name;
            this.location = location;
            this.description = description;
            this.commandID = 0;
        }

        public override void Execute()
        {
            ChannelFactory<IAddItem> factory = new ChannelFactory<IAddItem>("AddItem");
            IAddItem proxy = factory.CreateChannel();

            commandID = proxy.GetAvailableCommandID();
            owner = proxy.FindPerson(username);
            //Person finder = proxy.FindPerson(tbPronalazac.Text);
            Item item = new Item(date, name, location, description, owner, null, false);
            item.ItemCommandID = commandID;

            proxy.Add(item);

        }


        public override void Unexecute()
        {
            ChannelFactory<IAddItem> factory = new ChannelFactory<IAddItem>("AddItem");
            IAddItem proxy = factory.CreateChannel();
            proxy.UnAdd(commandID);


        }
    }
}
