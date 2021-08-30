using Common;
using Front.Commands;
using Front.Commands.LocalCommands;
using Front.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Front.SearchCriterias
{
    public static class SearchCommandExecutor
    {
        public static List<ItemModel> ExecuteSearch(List<ItemModel> sourceList, string date1, string date2, string itemTitle, string location, string ownerUsername, string finderUsername)
        {
            if (sourceList.Count > 0)
            {
                List<ItemModel> retList = new List<ItemModel>();
                DateTime d1;
                DateTime d2;
                if (!String.IsNullOrEmpty(date1))
                    d1 = Convert.ToDateTime(date1);
                else
                    d1 = DateTime.MinValue;
                if (!String.IsNullOrEmpty(date2))
                    d2 = Convert.ToDateTime(date2);
                else
                    d2 = DateTime.MaxValue;

                ISearchCriteria dateSearch = new SearchByDate();
                ISearchCriteria titleSearch = new SearchByTitle();
                ISearchCriteria locationSearch = new SearchByLocation();
                ISearchCriteria ownerSearch = new SearchByOwnerUsername();
                ISearchCriteria finderSearch = new SearchByFinderUsername();

                retList = dateSearch.Search(sourceList, new SearchParameters(d1, d2));
                retList = titleSearch.Search(retList, new SearchParameters(itemTitle));
                retList = locationSearch.Search(retList, new SearchParameters(location));
                retList = ownerSearch.Search(retList, new SearchParameters(ownerUsername));
                retList = finderSearch.Search(retList, new SearchParameters(finderUsername));

                return retList;
            }
            else
                return null;

        }
    }
}
