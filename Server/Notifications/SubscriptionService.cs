using Common.Services;
using Logger;
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
        ILoggingManager loggingManager;

        public SubscriptionService()
        {
            registeredUsersCnt = 0;
            clientList = new List<IClientNotification>();
            loggingManager = new LoggingManager();
            
        }

        public void NotifyAll()
        {
            foreach(IClientNotification cl in clientList)
            {
                cl.NotifyForChanges();
            }
            EventLog eventLog = new EventLog(DateTime.Now, Status.INFO, "EXECUTED_NOTIFY_ALL_METHOD: All clients are notified");
            loggingManager.LogEvent(eventLog);
        }

        public void Subscribe()
        {
            client = OperationContext.Current.GetCallbackChannel<IClientNotification>();
            if(!clientList.Contains(client) && client != null)
            {
                clientList.Add(client);
                registeredUsersCnt++;

                EventLog eventLog = new EventLog(DateTime.Now, Status.INFO, $"EXECUTED_SUBSCRIBE_METHOD: Client on channel {client.ToString()} has been subscribed");
                loggingManager.LogEvent(eventLog);
            }
        }

        public void Unsubscribe()
        {
            client = OperationContext.Current.GetCallbackChannel<IClientNotification>();
            if(clientList.Contains(client))
            {
                clientList.Remove(client);
                registeredUsersCnt--;

                EventLog eventLog = new EventLog(DateTime.Now, Status.INFO, $"EXECUTED_UNSUBSCRIBE_METHOD: Client on channel {client.ToString()} has been unsubscribed");
                loggingManager.LogEvent(eventLog);
            }
        }
    }
}
