using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Common.Services
{
    [ServiceContract]
    public interface IRetrievePersonItems
    {
        [OperationContract]
        List<Item> GetPersonItems(Person person);
    }
}
