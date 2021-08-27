using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Common.Services
{
    [ServiceContract(CallbackContract = typeof(IClientNotification), SessionMode = SessionMode.Required)]
    public interface ISubscription
    {
        [OperationContract(IsOneWay = true)]
        void Subscribe();
        [OperationContract(IsOneWay = true)]
        void Unsubscribe();
        [OperationContract(IsOneWay = false)]
        void NotifyAll();
    }
}
