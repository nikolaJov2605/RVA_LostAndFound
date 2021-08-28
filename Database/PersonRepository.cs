using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Database.PersonCommands;
using Database.PersonCommands.PersonsQueries;
using Database.PersonsCommands;

namespace Database
{
    public static class PersonRepository
    {
        public static void ExecuteCommand(PersonDBUpdateCommand command)
        {
            command.Execute();
        }

        public static List<Person> ExecuteQuery(PersonQueries query)
        {
            return query.Execute();
        }
        public static bool ExecuteCheck(PersonCheckings check)
        {
            return check.Execute();
        }
        public static Person ExecuteQuery(SinglePersonQuery query)
        {
            return query.Execute();
        }
    }
}
