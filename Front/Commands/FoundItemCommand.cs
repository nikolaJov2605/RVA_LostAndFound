using Common.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Front.Commands
{
    public class FoundItemCommand : Command
    {
        private int key;
        private string finderUsername;

        public FoundItemCommand(int id, string finder)
        {
            key = id;
            finderUsername = finder;
        }

        public override void Execute()
        {
            ChannelFactory<ISetItemIsFound> factory = new ChannelFactory<ISetItemIsFound>("IsItemFound");
            ISetItemIsFound proxy = factory.CreateChannel();
            proxy.ItemFound(key, finderUsername);
        }

        public override void Unexecute()
        {
            ChannelFactory<ISetItemIsFound> factory = new ChannelFactory<ISetItemIsFound>("IsItemFound");
            ISetItemIsFound proxy = factory.CreateChannel();
            proxy.ItemNotFound(key);
        }
    }
}
