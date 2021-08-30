using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace Front.Model
{
    public class PersonModel
    {
        private string username;
        private string password;
        private string name;
        private string lastName;
        private DateTime birthdate;
        private Role role;
        private int roleView;

        public string Username
        {
            get { return username; }
            set
            {
                if (username != value)
                {
                    username = value;
                    RaisePropertyChanged("Name");
                }
            }
        }

        public string Password
        {
            get { return password; }
            set
            {
                if (password != value)
                {
                    password = value;
                    RaisePropertyChanged("Password");
                }
            }
        }

        public string Name
        {
            get { return name; }
            set
            {
                if (name != value)
                {
                    name = value;
                    RaisePropertyChanged("Name");
                    RaisePropertyChanged("FullName");
                }
            }
        }

        public string LastName
        {
            get { return lastName; }
            set
            {
                if (lastName != value)
                {
                    lastName = value;
                    RaisePropertyChanged("LastName");
                    RaisePropertyChanged("FullName");
                }
            }
        }

        public DateTime Birthdate
        {
            get { return birthdate; }
            set
            {
                if(birthdate != value)
                {
                    birthdate = value;
                    RaisePropertyChanged("Birthdate");
                }
            }

        }

        public Role Role
        {
            get
            {
                return role;
            }
            set
            {
                if (role != value)
                {
                    role = value;
                    RaisePropertyChanged("Role");
                }    
            }
        }

        public int RoleView
        {
            get { return (int)Role + 1; }
            set
            {
                if(roleView != value)
                {
                    roleView = value;
                    RaisePropertyChanged("RoleView");
                }
            }
        }

        public string FullName
        {
            get { return name + " " + lastName; }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }
}
