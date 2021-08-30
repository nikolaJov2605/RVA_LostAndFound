using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Common.Services
{
    [ServiceContract]
    public interface IAddItem
    {
        [OperationContract]
        bool Add(Item item);

        [OperationContract]
        int GetAvailableCommandID();

        [OperationContract]
        Person FindPerson(string username);

        [OperationContract]
        bool UnAdd(int commandID);

        [OperationContract]
        void AddMulitpleItems(List<Item> items);
    }
}
