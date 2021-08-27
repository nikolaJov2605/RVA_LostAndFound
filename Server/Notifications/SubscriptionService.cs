using Common.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Server.Notifications
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple, InstanceContextMode = InstanceContextMode.Single)]
    public class SubscriptionService : ISubscription
    {
        private static List<IClientNotification> clientList;
        private int registeredUsersCnt;
        private IClientNotification client = null;

        public SubscriptionService()
        {
            registeredUsersCnt = 0;
            clientList = new List<IClientNotification>();
        }

        public void NotifyAll()
        {
            foreach(IClientNotification cl in clientList)
            {
                cl.NotifyForChanges();
            }
        }

        public void Subscribe()
        {
            client = OperationContext.Current.GetCallbackChannel<IClientNotification>();
            if(!clientList.Contains(client) && client != null)
            {
                clientList.Add(client);
                registeredUsersCnt++;
            }
        }

        public void Unsubscribe()
        {
            client = OperationContext.Current.GetCallbackChannel<IClientNotification>();
            if(clientList.Contains(client))
            {
                clientList.Remove(client);
                registeredUsersCnt--;
            }
        }
    }
}
