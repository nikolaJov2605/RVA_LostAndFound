using Front.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Front.Commands.LocalCommands
{
    public class LocalCommandInvoker : CommandInvoker
    {
        public List<Command> commandHistory;
        private int currentCommandIdx;

        public LocalCommandInvoker()
        {
            commandHistory = new List<Command>();
            currentCommandIdx = -1;
        }

        public override void AddAndExecuteCommand(Command command, MainWindow mw)
        {
            commandHistory.Add(command);
            command.Execute();
            currentCommandIdx = commandHistory.Count - 1;
            commandHistory.RemoveRange(currentCommandIdx, commandHistory.Count - 1 - currentCommandIdx);

            mw = MainWindow.MainWindowInstance();
            
        }

        public override void Undo()
        {
            if (currentCommandIdx < 0)
                return;
            commandHistory[currentCommandIdx].Unexecute();

            currentCommandIdx--;
        }

        public override void Redo()
        {
            if(currentCommandIdx + 1 >= commandHistory.Count)
                return;

            currentCommandIdx++;
            commandHistory[currentCommandIdx].Execute();
        }


    }
}
