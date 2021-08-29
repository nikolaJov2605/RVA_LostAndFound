using Common;
using Front.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Front.SearchCriterias
{
    public class SearchByDate : ISearchCriteria
    {
        public SearchByDate()
        {

        }

        public List<ItemModel> Search(List<ItemModel> list, SearchParameters searchParameter)
        {
            if (searchParameter.DateTimeParameter1 != null && searchParameter.DateTimeParameter2 == null)
                return list.Where(x => Convert.ToDateTime(x.Date) >= searchParameter.DateTimeParameter1).ToList();
            else if (searchParameter.DateTimeParameter1 == null && searchParameter.DateTimeParameter2 != null)
                return list.Where(x => Convert.ToDateTime(x.Date) <= searchParameter.DateTimeParameter2).ToList();
            else if (searchParameter.DateTimeParameter1 != null && searchParameter.DateTimeParameter2 != null)
                return list.Where(x => Convert.ToDateTime(x.Date) >= searchParameter.DateTimeParameter1 && Convert.ToDateTime(x.Date) <= searchParameter.DateTimeParameter2).ToList();
            else
                return list;
        }
    }
}
