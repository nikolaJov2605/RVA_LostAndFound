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

        public CommandInvoker()
        {
            commandHistory = new List<Command>();
            currentCommandIdx = 0;
        }

        public void AddAndExecuteCommand(Command command)
        {
            commandHistory.Add(command);
            command.Execute();
            currentCommandIdx = commandHistory.Count;
            commandHistory.RemoveRange(currentCommandIdx, commandHistory.Count - currentCommandIdx);
        }

        public void Undo()
        {
            if (commandHistory.Count - 1 < 0)
                return;
            commandHistory[commandHistory.Count - 1].Unexecute();
            currentCommandIdx--;
        }

        public void Redo()
        {
            if (currentCommandIdx + 1 > commandHistory.Count)
                return;

            currentCommandIdx++;
            commandHistory[currentCommandIdx].Execute();
            
        }
    }
}
