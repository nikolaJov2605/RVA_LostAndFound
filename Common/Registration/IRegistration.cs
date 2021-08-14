using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Common.Registration
{
    [ServiceContract]
    public interface IRegistration
    {
        [OperationContract]
        bool Register(Person person);
    }
}
