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
    public class ModifyPersonService : IModifyPerson
    {
        public void ModifyPerson(Person p)
        {
            PersonDBUpdateCommand modifyCommand = new ModifyPersonDBCommand(p);
            PersonRepository.ExecuteCommand(modifyCommand);
        }
    }
}
