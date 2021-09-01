using Common;
using Front.Model;
using Front.SearchCriterias;
using Logger;
using System;
using System.Collections.Generic;

namespace Front.Commands.LocalCommands
{
    public class SearchCommand : Command
    {
        protected ISearchCriteria searchCriteria;

        private SearchParameters parameters;
        private List<ItemModel> sourceList;
        private ILoggingManager loggingManager;
        
        public SearchCommand(List<ItemModel> source, SearchParameters srchParams)
        {
            sourceList = source;
            parameters = srchParams;
            loggingManager = new LoggingManager();
        }

        public override void Execute()
        {
            searchCriteria.Search(sourceList, parameters);

            EventLog eventLog = new EventLog(DateTime.Now, Status.INFO, $"EXECUTED SEARCH COMMAND: Frontend items list updated");
            loggingManager.LogEvent(eventLog);
        }

        public override void Unexecute()
        {
            return;
        }
    }
}
