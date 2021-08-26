using Common.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Server.Notifications
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Single, InstanceContextMode = InstanceContextMode.PerCall)]
    public class SubscriptionService : ISubscription
    {
        private static List<IClientNotification> clientList = new List<IClientNotification>();
        private int registeredUsersCnt;

        public SubscriptionService() { }

        public void NotifyAll()
        {
            foreach(IClientNotification cl in clientList)
            {
                cl.NotifyForChanges();
            }
        }

        public int Subscribe()
        {
            IClientNotification registeredClient = OperationContext.Current.GetCallbackChannel<IClientNotification>();
            if(!clientList.Contains(registeredClient))
            {
                clientList.Add(registeredClient);
                registeredUsersCnt++;
            }
            return registeredUsersCnt;
        }

        public int Unsubscribe()
        {
            IClientNotification client = OperationContext.Current.GetCallbackChannel<IClientNotification>();
            if(clientList.Contains(client))
            {
                clientList.Remove(client);
                registeredUsersCnt--;
            }
            return registeredUsersCnt;
        }
    }
}
