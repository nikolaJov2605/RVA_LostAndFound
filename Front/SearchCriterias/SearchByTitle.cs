using Common;
using Front.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Front.SearchCriterias
{
    public class SearchByTitle : ISearchCriteria
    {
        public SearchByTitle()
        {

        }

        public List<ItemModel> Search(List<ItemModel> list, SearchParameters searchParameter)
        {
            if (!String.IsNullOrEmpty(searchParameter.TextParameter))
                return list.Where(x => x.Title.ToLower().Contains(searchParameter.TextParameter.ToLower())).ToList();
            else
                return list;
        }
    }
}
