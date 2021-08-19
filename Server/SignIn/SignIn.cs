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
    public class SignIn : ISignIn
    {
        bool ISignIn.SignIn(string username, string password)
        {
            Person person = PersonRepository.FindByUsername(username);
            if (person != null && person.Password == password)
            {
                // login
                Console.WriteLine("SignIn successfull");
                return true;
            }
            else
            {
                Console.WriteLine("Username or password incorect");
                return false;
            }
        }
    }
}
