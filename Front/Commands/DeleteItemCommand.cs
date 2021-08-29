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
    public class DeleteItemCommand : Command
    {
        private int key;
        private Item item;

        public DeleteItemCommand(int k)
        {
            key = k;
        }

        public override void Execute()
        {
            ChannelFactory<IDeleteItem> factory = new ChannelFactory<IDeleteItem>("DeleteItem");
            IDeleteItem proxy = factory.CreateChannel();

            item = proxy.FindItem(key);


            proxy.DeleteItem(key);
        }

        public override void Unexecute()
        {
            ChannelFactory<IAddItem> factory = new ChannelFactory<IAddItem>("AddItem");
            IAddItem proxy = factory.CreateChannel();
            proxy.Add(item);
        }
    }
}
