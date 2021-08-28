using Common.Services;
using Front.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
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
            currentCommandIdx = -1;
        }

        public void AddAndExecuteCommand(Command command, MainWindow mw)
        {
            commandHistory.Add(command);
            command.Execute();
            currentCommandIdx = commandHistory.Count - 1;
            commandHistory.RemoveRange(currentCommandIdx, commandHistory.Count - 1 - currentCommandIdx);

            mw = MainWindow.MainWindowInstance();
            InstanceContext callback = new InstanceContext(mw);
            DuplexChannelFactory<ISubscription> factory = new DuplexChannelFactory<ISubscription>(callback, "UserSubscription");
            ISubscription proxy = factory.CreateChannel();
            proxy.NotifyAll();
        }

        public void Undo()
        { 
            if (currentCommandIdx < 0)
                return;
            commandHistory[currentCommandIdx].Unexecute();

            MainWindow mw = MainWindow.MainWindowInstance();
            InstanceContext callback = new InstanceContext(mw);
            DuplexChannelFactory<ISubscription> factory = new DuplexChannelFactory<ISubscription>(callback, "UserSubscription");
            ISubscription proxy = factory.CreateChannel();
            proxy.NotifyAll();

            currentCommandIdx--;
        }

        public void Redo()
        {
            if (currentCommandIdx + 1 >= commandHistory.Count)
                return;

            currentCommandIdx++;
            commandHistory[currentCommandIdx].Execute();

            MainWindow mw = MainWindow.MainWindowInstance();
            InstanceContext callback = new InstanceContext(mw);
            DuplexChannelFactory<ISubscription> factory = new DuplexChannelFactory<ISubscription>(callback, "UserSubscription");
            ISubscription proxy = factory.CreateChannel();
            proxy.NotifyAll();

        }
    }
}
