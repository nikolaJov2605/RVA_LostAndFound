using Front.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Front.ViewModel
{
    public class ModifyItemViewModel
    {
        private static ItemModel item;
        public static ItemModel Item
        {
            get { return item; }
            set { item = value; }
        }

        public ModifyItemViewModel()
        {
            
        }
    }
}
