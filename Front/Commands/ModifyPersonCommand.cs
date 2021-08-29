using Common;
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
    public class ModifyPersonCommand : Command
    {
        private Person person;
        private string newName;
        private string newLastName;

        private string oldName;
        private string oldLastName;

        private MainWindow mainWindow;
        public ModifyPersonCommand(Person p, string nn, string nln, MainWindow mw)
        {
            person = p;
            newName = nn;
            newLastName = nln;

            oldName = p.Name;
            oldLastName = p.LastName;

            mainWindow = MainWindow.MainWindowInstance();
        }
        public override void Execute()
        {
            person.Name = newName;
            person.LastName = newLastName;

            ChannelFactory<IModifyPerson> channelFactory = new ChannelFactory<IModifyPerson>("PersonModify");
            IModifyPerson modifyProxy = channelFactory.CreateChannel();
            modifyProxy.ModifyPerson(person);


            mainWindow.lblName.Content = newName;
            mainWindow.lblLastName.Content = newLastName;
        }

        public override void Unexecute()
        {
            person.Name = oldName;
            person.LastName = oldLastName;

            ChannelFactory<IModifyPerson> channelFactory = new ChannelFactory<IModifyPerson>("PersonModify");
            IModifyPerson modifyProxy = channelFactory.CreateChannel();
            modifyProxy.ModifyPerson(person);

            mainWindow.lblName.Content = oldName;
            mainWindow.lblLastName.Content = oldLastName;
        }
    }
}
