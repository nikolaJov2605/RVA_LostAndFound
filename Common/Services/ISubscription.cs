using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Common.Services
{
    [ServiceContract(CallbackContract = typeof(IClientNotification))]
    public interface ISubscription
    {
        [OperationContract]
        int Subscribe();
        [OperationContract(IsOneWay = true)]
        void NotifyAll();
        [OperationContract]
        int Unsubscribe();
    }
}
