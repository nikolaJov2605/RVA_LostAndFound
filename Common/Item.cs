using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    [DataContract]
    public class Item
    {
        public Item()
        {

        }

        public Item(int id, DateTime date, string title, string location, string description, Person owner, Person finder, bool isFound)
        {
            Id = id;
            Date = date;
            Title = title;
            Location = location;
            Description = description;
            Owner = owner;
            Finder = finder;
            IsFound = isFound;
        }

        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public DateTime Date { get; set; }
        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public string Location { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public Person Owner { get; set; }
        [DataMember]
        public Person Finder { get; set; }
        [DataMember]
        public bool IsFound { get; set; }
    }
}
