using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.ItemCommands.ItemsCheckings
{
    public class CommandIDExistCheck : ItemCheckings
    {
        private int commandID;

        public CommandIDExistCheck(int id)
        {
            commandID = id;
        }

        public override bool Execute()
        {
            AppDBContext context = new AppDBContext();

            try
            {
                var query = context.Items.Where(x => x.ItemCommandID == commandID).First<Item>();
                if (query != null)
                    return true;
            }
            catch
            {
                return false;
            }
            return false;
        }
    }
}
