﻿using Common.Services;
using Server.ItemServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
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
            Console.WriteLine("Server is fully up!");
            Console.ReadLine();
        }
    }
}
