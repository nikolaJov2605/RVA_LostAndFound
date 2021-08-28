using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.PersonCommands
{
    public abstract class PersonQueries
    {
        public abstract List<Person> Execute();
    }
}
