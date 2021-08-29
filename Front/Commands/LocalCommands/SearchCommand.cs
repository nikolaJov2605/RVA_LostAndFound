using Common;
using Front.Model;
using Front.SearchCriterias;
using System;
using System.Collections.Generic;

namespace Front.Commands.LocalCommands
{
    public class SearchCommand : Command
    {
        protected ISearchCriteria searchCriteria;

        private SearchParameters parameters;
        private List<ItemModel> sourceList;
        
        public SearchCommand(List<ItemModel> source, SearchParameters srchParams)
        {
            sourceList = source;
            parameters = srchParams;
        }

        public override void Execute()
        {
            searchCriteria.Search(sourceList, parameters);
        }

        public override void Unexecute()
        {
            throw new NotImplementedException();
        }
    }
}
