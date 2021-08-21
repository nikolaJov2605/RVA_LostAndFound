using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Front.Commands
{
    public class CommandInvoker
    {
        public List<Command> commandHistory;

        CommandInvoker()
        {
            commandHistory = new List<Command>();
        }

        public void AddCommand(Command command)
        {

        }

        public void Execute(Command command)
        {
            commandHistory.Add(command);
            command.Execute();
        }

        public void Unexecute(Command command)
        {
            command.Unexecute();
        }
    }
}
