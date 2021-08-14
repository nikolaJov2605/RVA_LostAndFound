using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Front.Model
{
    public class User
    {
        private string name;
        private string lastname;
        private DateTime datumRodjenja;
        private string jmbg;
        private string username;
        private string password;

        public User(string name, string lastname, DateTime datumRodjenja, string jmbg, string username, string password)
        {
            this.name = name;
            this.lastname = lastname;
            this.datumRodjenja = datumRodjenja;
            this.jmbg = jmbg;
            this.username = username;
            this.password = password;
        }

        public string Name { get => name; set => name = value; }
        public string Lastname { get => lastname; set => lastname = value; }
        public DateTime DatumRodjenja { get => datumRodjenja; set => datumRodjenja = value; }
        public string Jmbg { get => jmbg; set => jmbg = value; }
        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
    }
}
