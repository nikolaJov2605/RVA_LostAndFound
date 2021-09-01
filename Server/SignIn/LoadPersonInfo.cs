using Common;
using Common.Services;
using Database;
using Database.PersonCommands.SinglePersonsQueries;
using Database.PersonsCommands;
using Logger;
using System;

namespace Server.SignIn
{
    public class LoadPersonInfo : ILoadPersonInfo
    {
        ILoggingManager loggingManager = new LoggingManager();
        public Person Load(string username)
        {
            SinglePersonQuery personQuery = new FindByUsernameQuery(username);
            Person person = PersonRepository.ExecuteQuery(personQuery);


            EventLog eventLog = new EventLog(DateTime.Now, Status.INFO, $"EXECUTED LOAD_PERSON METHOD: person {username} loaded from database.");
            loggingManager.LogEvent(eventLog);

            return person;
        }
    }
}
