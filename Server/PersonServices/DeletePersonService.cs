using Common;
using Common.Services;
using Database;
using Database.PersonCommands;
using Database.PersonCommands.PersonUpdateCommands;
using Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.PersonServices
{
    public class DeletePersonService : IDeletePerson
    {
        ILoggingManager loggingManager = new LoggingManager();
        public void DeletePerson(Person p)
        {
            PersonDBUpdateCommand deleteCommand = new DeletePersonDBCommand(p);
            PersonRepository.ExecuteCommand(deleteCommand);

            EventLog eventLog = new EventLog(DateTime.Now, Status.INFO, $"EXECUTED_DELETE_PERSON_METHOD: Person {p.Username} has been deleted from database.");
            loggingManager.LogEvent(eventLog);
        }
    }
}
