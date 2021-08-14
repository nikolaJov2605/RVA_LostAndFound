using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    [DataContract]
    public  class Person
    {
        public Person(string username, string password, string name, string lastName, string birthDate, Role role)
        {
            Username = username;
            Password = password;
            Name = name;
            LastName = lastName;
            BirthDate = birthDate;
            Role = role;
        }

        [DataMember]
        [Key]
        public  string Username { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public string BirthDate { get; set; }
        [DataMember]
        public Role Role { get; set; }
    }
}
