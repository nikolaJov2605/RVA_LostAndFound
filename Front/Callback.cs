using Common.Services;
using Common;
using Front.ViewModel;
using Front.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Front.Model;

namespace Front
{
    public class Callback : IClientNotification
    {
        public EventHandler<List<Item>> DatabaseUpdatedEvent;
        public void NotifyForChanges()
        {
            /*MainDataViewModel.Items.Clear();
            foreach(var o in LoadItemsInfo.LoadItems())
            {
                MainDataViewModel.Items.Add(o);
            }*/
            MainDataViewModel.UpdateGrid();
            
        }
    }
}
