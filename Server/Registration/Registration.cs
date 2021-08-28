using Common;
using Common.Exceptions;
using Common.Services;
using Database;
using Database.PersonCommands;
using Database.PersonCommands.PersonsCheckings;
using Database.PersonCommands.PersonUpdateCommands;
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
        public bool Register(Person person)
        {
            PersonCheckings personExistsCheck = new PersonExistsCheck(person);
            if(PersonRepository.ExecuteCheck(personExistsCheck))
            {
                return false;
            }
            else
            {
                PersonDBUpdateCommand addPerson = new AddPersonDBCommand(person);
                PersonRepository.ExecuteCommand(addPerson);
                return true;
            }
        }
    }
}
