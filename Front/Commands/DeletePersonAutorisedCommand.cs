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
    public class DeletePersonAutorisedCommand : Command
    {
        private PersonModel personModel;

        private Person deletedPerson;
        private List<Item> deletedPersonItems;

        public DeletePersonAutorisedCommand(PersonModel model)
        {
            personModel = model;
            deletedPersonItems = new List<Item>();
        }


        public override void Execute()
        {
            deletedPerson = new Person(personModel.Username, personModel.Password, personModel.Name, personModel.LastName, personModel.Birthdate.ToString(), personModel.Role);

            ChannelFactory<IRetrievePersonItems> channelFactory = new ChannelFactory<IRetrievePersonItems>("RetrievePersonItems");
            IRetrievePersonItems retrieveItemsProxy = channelFactory.CreateChannel();
            deletedPersonItems = retrieveItemsProxy.GetPersonItems(deletedPerson);

            ChannelFactory<IDeletePerson> factory = new ChannelFactory<IDeletePerson>("PersonDelete");
            IDeletePerson proxy = factory.CreateChannel();

            proxy.DeletePerson(deletedPerson);
        
        }

        public override void Unexecute()
        {
            ChannelFactory<IRegistration> factory = new ChannelFactory<IRegistration>("UserRegistration");
            IRegistration proxy = factory.CreateChannel();

            proxy.Register(deletedPerson);

            ChannelFactory<IAddItem> channelFactory = new ChannelFactory<IAddItem>("AddItem");
            IAddItem addItemsProxy = channelFactory.CreateChannel();

            addItemsProxy.AddMulitpleItems(deletedPersonItems);
        }
    }
}
