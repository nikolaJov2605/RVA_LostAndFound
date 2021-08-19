using Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Front.Model
{
    public class ItemModel
    {
        private int id;
        private string date;
        private string title;
        private string location;
        private string description;
        private Person owner;
        private Person finder;
        private bool isFound;


        public int Id
        {
            get { return id; }
            set
            {
                if (id != value)
                {
                    id = value;
                    RaisePropertyChanged("ID");
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
        public Person Owner
        {
            get { return owner; }
            set
            {
                if(owner != value)
                {
                    owner = value;
                    RaisePropertyChanged("Owner");
                }
            }
        }
        public Person Finder
        {
            get { return finder; }
            set
            {
                if(finder != value)
                {
                    finder = value;
                    RaisePropertyChanged("Finder");
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
