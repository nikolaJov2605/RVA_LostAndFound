using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.PersonsCommands
{
    public abstract class SinglePersonQuery
    {
        public abstract Person Execute();
    }
}
