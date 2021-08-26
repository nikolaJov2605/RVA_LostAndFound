﻿using Common.Services;
using Server.ItemServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Database;
using Common;
using Server.Notifications;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            /*using (AppDBContext context = new AppDBContext())
            {
                //Truncate Table to delete all old records.
                context.Database.ExecuteSqlCommand("TRUNCATE TABLE [Items]");
            }*/

            ServiceHost registrationService = new ServiceHost(typeof(Registration.Registration));
            registrationService.Open();
            Console.WriteLine("Registration service is up...");

            ServiceHost loginService = new ServiceHost(typeof(SignIn.SignIn));
            loginService.Open();
            Console.WriteLine("Login service is up...");

            ServiceHost addItemService = new ServiceHost(typeof(AddItem));
            addItemService.Open();
            Console.WriteLine("AddItem service is up...");

            ServiceHost deleteItemService = new ServiceHost(typeof(DeleteItem));
            deleteItemService.Open();
            Console.WriteLine("DeleteItem service is up...");

            ServiceHost subscriptionService = new ServiceHost(typeof(SubscriptionService));
            subscriptionService.Open();
            Console.WriteLine("Subscription service is up...");

            ServiceHost retrieveItems = new ServiceHost(typeof(RetrieveItems));
            retrieveItems.Open();
            Console.WriteLine("RetrieveItems service is up...");
            Console.WriteLine("Server is fully up!");
            Console.ReadLine();
        }
    }
}
