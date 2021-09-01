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
    public class ModifyPersonService : IModifyPerson
    {
        ILoggingManager loggingManager = new LoggingManager();
        public void ModifyPerson(Person p)
        {
            PersonDBUpdateCommand modifyCommand = new ModifyPersonDBCommand(p);
            PersonRepository.ExecuteCommand(modifyCommand);

            EventLog eventLog = new EventLog(DateTime.Now, Status.INFO, $"EXECUTED_MODIFY_PERSON_METHOD: Person {p.Username} has been modified");
            loggingManager.LogEvent(eventLog);
        }
    }
}
