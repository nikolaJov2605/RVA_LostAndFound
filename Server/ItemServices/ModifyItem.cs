using Common;
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
    public class ModifyItem : IModifyItem
    {
        void IModifyItem.ModifyItem(Item toModify, Item modified)
        {
            ItemDBUpdateCommand modifyItemCommand = new ModifyItemDBCommand(toModify, modified);
            ItemRepository.ExecuteCommand(modifyItemCommand);
        }
    }
}
