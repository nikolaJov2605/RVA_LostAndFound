using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Common.Exceptions
{
    [DataContract]
    public class RegistrationException
    {
        private string reason;
        [DataMember]
        public string Reason { get => reason; set => reason = value; }
    }
}
