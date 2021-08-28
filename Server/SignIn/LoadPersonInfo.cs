using Common;
using Common.Services;
using Database;
using Database.PersonCommands.SinglePersonsQueries;
using Database.PersonsCommands;

namespace Server.SignIn
{
    public class LoadPersonInfo : ILoadPersonInfo
    {
        public Person Load(string username)
        {
            SinglePersonQuery personQuery = new FindByUsernameQuery(username);
            Person person = PersonRepository.ExecuteQuery(personQuery);
            return person;
        }
    }
}
