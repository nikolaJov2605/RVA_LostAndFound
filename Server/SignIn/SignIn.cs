using Common;
using Common.Services;
using Database;
using Database.PersonCommands.SinglePersonsQueries;
using Database.PersonsCommands;
using Logger;
using System;

namespace Server.SignIn
{
    public class SignIn : ISignIn
    {
        ILoggingManager loggingManager = new LoggingManager();
        bool ISignIn.SignIn(string username, string password)
        {
            SinglePersonQuery personQuery = new FindByUsernameQuery(username);
            Person person = PersonRepository.ExecuteQuery(personQuery);
            if (person != null && person.Password == password)
            {
                // login
                EventLog eventLog = new EventLog(DateTime.Now, Status.INFO, $"EXECUTED SIGN_IN METHOD: Person {username} successfully signed in");
                loggingManager.LogEvent(eventLog);
                return true;
            }
            else
            {
                EventLog eventLog = new EventLog(DateTime.Now, Status.INFO, $"EXECUTED SIGN_IN METHOD: Person {username} couldn't sign in. Wrong credentials");
                loggingManager.LogEvent(eventLog);
                return false;
            }
        }
    }
}
