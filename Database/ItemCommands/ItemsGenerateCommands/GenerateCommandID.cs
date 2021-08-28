using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.ItemCommands.ItemsGenerateCommands
{
    public class GenerateCommandID : ItemGeneration
    {
        public override int Execute()
        {
            using(AppDBContext context = new AppDBContext())
            {
                int id;
                if (context.Items.Count<Item>() == 0)
                    id = 0;
                else
                    id = context.Items.Max(x => x.Id);

                //id = (int)DateTime.Now.ToUniversalTime().Subtract(new DateTime(2020, 8, 28, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds;

                return id;
            }
        }
    }
}
