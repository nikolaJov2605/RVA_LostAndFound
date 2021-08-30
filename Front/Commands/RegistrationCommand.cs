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
    public class RegistrationCommand : Command
    {
        private Person person;

        public RegistrationCommand(Person p)
        {
            person = p;
        }


        public override void Execute()
        {
            ChannelFactory<IRegistration> factory = new ChannelFactory<IRegistration>("UserRegistration");
            IRegistration proxy = factory.CreateChannel();
            if(proxy.Register(person) == true)
            {
                Console.WriteLine("User " + person.Username + " registered");
                Registracija.Instance().Close();
                Registracija.DeleteInstance();
            }
        }

        public override void Unexecute()
        {
            ChannelFactory<IDeletePerson> factory = new ChannelFactory<IDeletePerson>("PersonDelete");
            IDeletePerson proxy = factory.CreateChannel();
            proxy.DeletePerson(person);
        }
    }
}
