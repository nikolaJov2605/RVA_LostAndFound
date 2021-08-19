using Front.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Front.ViewModel
{
    public class PersonViewModel
    {
        public PersonModel Person { get; set; }

        public PersonViewModel(string username)
        {
            PersonModel person = LoadLoggedPerson.LoadPerson(username);
            Person = person;
        }
    }
}
