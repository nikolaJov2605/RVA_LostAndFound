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
