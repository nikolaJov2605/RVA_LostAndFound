using Common;
using Common.Services;
using Front.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Front.Commands
{
    public class DuplicateCommand : Command
    {
        private ItemModel itemModel;
        private Item item;

        private int commandID;

        public DuplicateCommand(ItemModel model)
        {
            itemModel = model;
            commandID = 0;
        }

        public override void Execute()
        {
            item = ConvertToItem(itemModel);

            ChannelFactory<IAddItem> factory = new ChannelFactory<IAddItem>("AddItem");
            IAddItem proxy = factory.CreateChannel();
            commandID = proxy.GetAvailableCommandID();
            item.ItemCommandID = commandID;
            proxy.Add(item);

        }

        public override void Unexecute()
        {
            ChannelFactory<IAddItem> factory = new ChannelFactory<IAddItem>("AddItem");
            IAddItem proxy = factory.CreateChannel();
            proxy.UnAdd(item.ItemCommandID);
        }

        private Item ConvertToItem(ItemModel model)
        {
            ChannelFactory<ILoadPersonInfo> factory = new ChannelFactory<ILoadPersonInfo>("PersonInfo");
            ILoadPersonInfo proxy = factory.CreateChannel();
            Person owner = proxy.Load(model.OwnerUsername);
            Person finder = proxy.Load(model.FinderUsername);

            Item retItem = new Item(model.Date.ToString(), model.Title, model.Location, model.Description, owner, finder, model.IsFound);

            return retItem;
        }

    }
}
