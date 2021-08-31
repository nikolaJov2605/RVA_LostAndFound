using Common.Services;
using Database;
using Database.ItemCommands;
using Database.ItemCommands.ItemsUpdateCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.ItemServices
{
    public class SetItemIsFound : ISetItemIsFound
    {
        public void ItemFound(int key, string finderUsername)
        {
            ItemDBUpdateCommand itemFoundCommand = new SetItemFoundCommand(key, finderUsername);
            ItemRepository.ExecuteCommand(itemFoundCommand);
        }

        public void ItemNotFound(int key)
        {
            ItemDBUpdateCommand itemNotFoundCommand = new UndoItemFoundCommand(key);
            ItemRepository.ExecuteCommand(itemNotFoundCommand);
        }
    }
}
