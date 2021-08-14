using Common;
using Common.Exceptions;
using Common.Registration;
using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Server.Registration
{
    public class Registration : IRegistration
    {
        public bool Register(Person person)
        {

            if(PersonRepository.Exists(person))
            {
                return false;
            }
            else
            {
                PersonRepository.AddPerson(person);
                return true;
            }
        }
    }
}
