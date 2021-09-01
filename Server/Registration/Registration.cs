using Common;
using Common.Exceptions;
using Common.Services;
using Database;
using Database.PersonCommands;
using Database.PersonCommands.PersonsCheckings;
using Database.PersonCommands.PersonUpdateCommands;
using Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Server.Registration
{
    public class Registration : IRegistration
    {
        ILoggingManager loggingManager = new LoggingManager();
        public bool Register(Person person)
        {
            PersonCheckings personExistsCheck = new PersonExistsCheck(person);
            if(PersonRepository.ExecuteCheck(personExistsCheck))
            {
                EventLog eventLog = new EventLog(DateTime.Now, Status.ERROR, $"EXECUTED REGISTER METHOD: Registration failed because person with username {person.Username} allready exist in database.");
                loggingManager.LogEvent(eventLog);
                return false;
            }
            else
            {
                PersonDBUpdateCommand addPerson = new AddPersonDBCommand(person);
                PersonRepository.ExecuteCommand(addPerson);

                EventLog eventLog = new EventLog(DateTime.Now, Status.INFO, $"EXECUTED REGISTER METHOD: Person {person.Username} successfully registered.");
                loggingManager.LogEvent(eventLog);
                return true;
            }
        }
    }
}
