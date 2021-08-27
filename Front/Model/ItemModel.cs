using Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Front.Model
{
    public class ItemModel : INotifyPropertyChanged
    {
        private int id;
        private string date;
        private string title;
        private string location;
        private string description;
        private string ownerUsername;
        private string finderUsername;
        private bool isFound;

        public ItemModel(int id, string date, string title, string location, string description, string ownerUsername, string finderUsername, bool isFound)
        {
            this.id = id;
            this.date = date;
            this.title = title;
            this.location = location;
            this.description = description;
            this.ownerUsername = ownerUsername;
            this.finderUsername = finderUsername;
            this.isFound = isFound;
        }

        public ItemModel() { }

        public int Id
        {
            get { return id; }
            set
            {
                if (id != value)
                {
                    id = value;
                    RaisePropertyChanged("Id");
                }
            }
        }
        public string Date
        {
            get { return date; }
            set
            {
                if (date != value)
                {
                    date = value;
                    RaisePropertyChanged("Date");
                }
            }
        }
        public string Title
        {
            get { return title; }
            set
            {
                if (title != value)
                {
                    title = value;
                    RaisePropertyChanged("Title");
                }
            }
        }
        public string Location
        {
            get { return location; }
            set
            {
                if (location != value)
                {
                    location = value;
                    RaisePropertyChanged("Location");
                }
            }
        }
        public string Description
        {
            get { return description; }
            set
            {
                if (description != value)
                {
                    description = value;
                    RaisePropertyChanged("Description");
                }
            }
        }
        public string OwnerUsername
        {
            get { return ownerUsername; }
            set
            {
                if(ownerUsername != value)
                {
                    ownerUsername = value;
                    RaisePropertyChanged("OwnerUsername");
                }
            }
        }
        public string FinderUsername
        {
            get { return finderUsername; }
            set
            {
                if(finderUsername != value)
                {
                    finderUsername = value;
                    RaisePropertyChanged("FinderUsername");
                }    
            }
        }
        public bool IsFound
        {
            get { return isFound; }
            set
            {
                if(isFound != value)
                {
                    isFound = value;
                    RaisePropertyChanged("IsFound");
                }
            }
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
