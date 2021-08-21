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
        private int currentCommandIdx;

        CommandInvoker()
        {
            commandHistory = new List<Command>();
            currentCommandIdx = -1;
        }

        public void AddAndExecuteCommand(Command command)
        {
            commandHistory.Add(command);
            commandHistory.RemoveRange(currentCommandIdx, commandHistory.Count - currentCommandIdx);
            command.Execute();
            currentCommandIdx = commandHistory.Count - 1;
        }

        public void Undo()
        {
            commandHistory[commandHistory.Count - 1].Unexecute();
            currentCommandIdx--;
        }

        public void Unexecute()
        {
            if (currentCommandIdx + 1 >= commandHistory.Count)
                return;

            currentCommandIdx++;
            commandHistory[currentCommandIdx].Execute();
            
        }
    }
}
