using Common;
using Front.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Front.SearchCriterias
{
    public interface ISearchCriteria
    {
        List<ItemModel> Search(List<ItemModel> list, SearchParameters searchParameter);
    }
}
