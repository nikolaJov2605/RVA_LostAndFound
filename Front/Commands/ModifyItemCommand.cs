using Common;
using Common.Services;
using Front.Model;
using Front.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Front.Commands
{
    public class ModifyItemCommand : Command
    {
        private int id;
        private string date;
        private string description;
        private string title;
        private string location;
        private bool isFound;
        private string ownerUsername;
        private string finderUsername;

        private Item oldItem;
        private Item newItem;

        public ModifyItemCommand(int id, string date, string description, string title, string location, bool isFound, string ownerUsername, string finderUsername)
        {
            this.id = id;
            this.date = date;
            this.description = description;
            this.title = title;
            this.location = location;
            this.isFound = isFound;
            this.ownerUsername = ownerUsername;
            this.finderUsername = finderUsername;
        }

        public override void Execute()
        {
            ChannelFactory<ILoadPersonInfo> loadPersonFactory = new ChannelFactory<ILoadPersonInfo>("PersonInfo");
            ILoadPersonInfo loadPersonProxy = loadPersonFactory.CreateChannel();
            Person owner = loadPersonProxy.Load(ownerUsername);
            Person finder = loadPersonProxy.Load(finderUsername);


            newItem = new Item(date, title, location, description, owner, finder, isFound);
            newItem.Id = id;

            ChannelFactory<ILoadItem> loadItemFactory = new ChannelFactory<ILoadItem>("LoadItem");
            ILoadItem loadItemProxy = loadItemFactory.CreateChannel();
            oldItem = loadItemProxy.Load(id);

            ChannelFactory<IModifyItem> factory = new ChannelFactory<IModifyItem>("ModifyItem");
            IModifyItem proxy = factory.CreateChannel();
            proxy.ModifyItem(oldItem, newItem);
        }

        public override void Unexecute()
        {
            ChannelFactory<IModifyItem> factory = new ChannelFactory<IModifyItem>("ModifyItem");
            IModifyItem proxy = factory.CreateChannel();
            proxy.ModifyItem(newItem, oldItem);
        }
    }
}
