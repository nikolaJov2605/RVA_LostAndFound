using Common;
using Common.Services;
using Database;
using Database.PersonCommands.SinglePersonsQueries;
using Database.PersonsCommands;
using System;

namespace Server.SignIn
{
    public class SignIn : ISignIn
    {
        bool ISignIn.SignIn(string username, string password)
        {
            SinglePersonQuery personQuery = new FindByUsernameQuery(username);
            Person person = PersonRepository.ExecuteQuery(personQuery);
            if (person != null && person.Password == password)
            {
                // login
                Console.WriteLine("SignIn successfull");
                return true;
            }
            else
            {
                Console.WriteLine("Username or password incorect");
                return false;
            }
        }
    }
}
