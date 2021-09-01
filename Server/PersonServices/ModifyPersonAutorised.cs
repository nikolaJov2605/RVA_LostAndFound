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
    public class ModifyPersonAutorised : IModifyPersonAutorised
    {
        ILoggingManager loggingManager = new LoggingManager();
        public void Modify(Person person)
        {
            PersonDBUpdateCommand updatePersonCommand = new ModifyPersonDBAutorisedCommand(person);
            PersonRepository.ExecuteCommand(updatePersonCommand);

            EventLog eventLog = new EventLog(DateTime.Now, Status.INFO, $"EXECUTED_MODIFY_PERSON_METHOD: Person {person.Username} has been modified.");
            loggingManager.LogEvent(eventLog);
        }
    }
}
