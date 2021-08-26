using Common;
using Common.Services;
using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Front
{
    public class LoadItemsInfo
    {
        public static List<Item> LoadItems()
        {
            ChannelFactory<IRetrieveItems> factory = new ChannelFactory<IRetrieveItems>("RetrieveItems");
            IRetrieveItems proxy = factory.CreateChannel();

            return proxy.RetrieveAllItems();
        }
    }
}
