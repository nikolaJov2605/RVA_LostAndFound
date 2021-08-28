using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.ItemCommands.ItemsCheckings
{
    public class KeyExistCheck : ItemCheckings
    {
        private int key;

        public KeyExistCheck(int k)
        {
            key = k;
        }

        public override bool Execute()
        {
            AppDBContext context = new AppDBContext();

            try
            {
                var query = context.Items.Where(x => x.Id == key).First<Item>();
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
