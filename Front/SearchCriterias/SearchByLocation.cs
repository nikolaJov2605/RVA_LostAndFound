﻿using Common;
using Front.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Front.SearchCriterias
{
    public class SearchByLocation : ISearchCriteria
    {
        public SearchByLocation()
        {

        }

        public List<ItemModel> Search(List<ItemModel> list, SearchParameters searchParameter)
        {
            if (!String.IsNullOrEmpty(searchParameter.TextParameter))
                return list.Where(x => x.Location.ToLower().Contains(searchParameter.TextParameter.ToLower())).ToList();
            else
                return list;
        }
    }
}
