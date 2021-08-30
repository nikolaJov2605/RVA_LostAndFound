using Common;
using Front.Model;
using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Services;
using System.ServiceModel;

namespace Front
{
    public static class LoadLoggedPerson
    {
        public static PersonModel LoadPerson(string username)
        {
            PersonModel retPerson = new PersonModel();
            ChannelFactory<ILoadPersonInfo> factory = new ChannelFactory<ILoadPersonInfo>("PersonInfo");
            ILoadPersonInfo proxy = factory.CreateChannel();

            Person person = proxy.Load(username);
            if(person != null)
            {
                retPerson.Username = person.Username;
                retPerson.Name = person.Name;
                retPerson.LastName = person.LastName;
                retPerson.Birthdate = Convert.ToDateTime(person.BirthDate);
                retPerson.Role = person.Role;

                return retPerson;
            }
            return null;
        }
    }
}
