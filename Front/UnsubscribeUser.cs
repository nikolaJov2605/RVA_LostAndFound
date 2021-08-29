using Common.Services;
using Front.Views;
using Server.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Front
{
    public static class UnsubscribeUser
    {
        public static void Unsubscribe()
        {
            InstanceContext context = new InstanceContext(MainWindow.MainWindowInstance());
            DuplexChannelFactory<ISubscription> factory = new DuplexChannelFactory<ISubscription>(context, "UserSubscription");
            ISubscription proxy = factory.CreateChannel();
            proxy.Unsubscribe();
        }
    }
}
