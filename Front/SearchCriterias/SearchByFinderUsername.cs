using Common;
using Front.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Front.SearchCriterias
{
    public class SearchByFinderUsername : ISearchCriteria
    {
        public SearchByFinderUsername()
        {

        }

        public List<ItemModel> Search(List<ItemModel> list, SearchParameters searchParameter)
        {
            List<ItemModel> retList = new List<ItemModel>();
            if (!String.IsNullOrEmpty(searchParameter.TextParameter))
            {
                foreach(ItemModel i in list)
                {
                    if (!String.IsNullOrEmpty(i.FinderUsername) && i.FinderUsername.ToLower().Contains(searchParameter.TextParameter.ToLower()))
                    {
                        retList.Add(i);
                    }
                }
                return retList;
            }
            else
                return list;
        }
    }
}
