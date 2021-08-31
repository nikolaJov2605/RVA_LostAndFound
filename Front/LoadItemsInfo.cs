using Common;
using Common.Services;
using Database;
using Front.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Front
{
    public class LoadItemsInfo
    {
        public static ObservableCollection<ItemModel> LoadItems()
        {
            ChannelFactory<IRetrieveItems> factory = new ChannelFactory<IRetrieveItems>("RetrieveItems");
            IRetrieveItems proxy = factory.CreateChannel();
            List<Item> tempList = proxy.RetrieveAllItems();
            ObservableCollection<ItemModel> retList = new ObservableCollection<ItemModel>();


            foreach (Item i in tempList)
            {
                DateTime d = Convert.ToDateTime(i.Date);
                
                if(i.Finder == null)
                {
                    retList.Add(new ItemModel
                    {
                        Id = i.Id,
                        Date = d,
                        Title = i.Title,
                        Location = i.Location,
                        Description = i.Description,
                        OwnerUsername = i.Owner.Username,
                        FinderUsername = null,
                        IsFound = i.IsFound
                    });
                }
                else
                {
                    retList.Add(new ItemModel
                    {
                        Id = i.Id,
                        Date = d,
                        Title = i.Title,
                        Location = i.Location,
                        Description = i.Description,
                        OwnerUsername = i.Owner.Username,
                        FinderUsername = i.Finder.Username,
                        IsFound = i.IsFound
                    });
                }
            }
            return retList;
        }
    }
}
