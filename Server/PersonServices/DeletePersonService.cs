using Common;
using Common.Services;
using Database;
using Database.PersonCommands;
using Database.PersonCommands.PersonUpdateCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.PersonServices
{
    public class DeletePersonService : IDeletePerson
    {
        public void DeletePerson(Person p)
        {
            PersonDBUpdateCommand deleteCommand = new DeletePersonDBCommand(p);
            PersonRepository.ExecuteCommand(deleteCommand);
        }
    }
}
