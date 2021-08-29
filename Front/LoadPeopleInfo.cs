using Common;
using Common.Services;
using Front.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ServiceModel;

namespace Front
{
    public class LoadPeopleInfo
    {
        public static ObservableCollection<PersonModel> LoadPeople()
        {
            ChannelFactory<IRetrievePeople> factory = new ChannelFactory<IRetrievePeople>("RetrievePeople");
            IRetrievePeople proxy = factory.CreateChannel();
            List<Person> tempList = proxy.LoadPeople();
            ObservableCollection<PersonModel> retList = new ObservableCollection<PersonModel>();


            foreach (Person p in tempList)
            {
                DateTime d = Convert.ToDateTime(p.BirthDate);

                retList.Add(new PersonModel
                {
                    Username = p.Username,
                    Name = p.Name,
                    LastName = p.LastName,
                    Birthdate = p.BirthDate,
                    Role = p.Role
                });
            }
            return retList;
        }
            
    }
}
