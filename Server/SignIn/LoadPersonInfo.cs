using Common;
using Common.Services;
using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SignIn
{
    public class LoadPersonInfo : ILoadPersonInfo
    {
        public Person Load(string username)
        {
            Person person = PersonRepository.FindByUsername(username);
            return person;
        }
    }
}
