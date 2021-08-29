using Common;
using Common.Services;
using Front.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Front.Commands
{
    public class AutorisedModifyPersonCommand : Command
    {
        private Person oldPerson;
        private Person newPerson;

        public AutorisedModifyPersonCommand(Person person)
        {
            newPerson = person;
        }

        public override void Execute()
        {

            ChannelFactory<ILoadPersonInfo> factory = new ChannelFactory<ILoadPersonInfo>("PersonInfo");
            ILoadPersonInfo proxy = factory.CreateChannel();
            oldPerson = proxy.Load(newPerson.Username);

            ChannelFactory<IModifyPersonAutorised> modifyFactory = new ChannelFactory<IModifyPersonAutorised>("ModifyPersonAutorised");
            IModifyPersonAutorised modifyProxy = modifyFactory.CreateChannel();
            modifyProxy.Modify(newPerson);

        }

        public override void Unexecute()
        {
            ChannelFactory<IModifyPersonAutorised> modifyFactory = new ChannelFactory<IModifyPersonAutorised>("ModifyPersonAutorised");
            IModifyPersonAutorised modifyProxy = modifyFactory.CreateChannel();
            modifyProxy.Modify(oldPerson);
        }



    }
}
