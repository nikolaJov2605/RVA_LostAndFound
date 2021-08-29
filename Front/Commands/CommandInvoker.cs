using Front.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Front.Commands
{
    public abstract class CommandInvoker
    {
        public abstract void AddAndExecuteCommand(Command command, MainWindow mw);

        public abstract void Undo();

        public abstract void Redo();
    }
}
