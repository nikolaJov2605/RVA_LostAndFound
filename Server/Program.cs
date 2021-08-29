using Common.Services;
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
using Server.SignIn;

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
            }

            using (AppDBContext context = new AppDBContext())
            {
                //Truncate Table to delete all old records.
                context.Database.ExecuteSqlCommand("DELETE FROM [People]");
            }*/

            ServiceHost registrationService = new ServiceHost(typeof(Registration.Registration));
            registrationService.Open();
            Console.WriteLine("Registration service is up...");

            ServiceHost loginService = new ServiceHost(typeof(SignIn.SignIn));
            loginService.Open();
            Console.WriteLine("Login service is up...");

            ServiceHost deletePersonService = new ServiceHost(typeof(PersonServices.DeletePersonService));
            deletePersonService.Open();
            Console.WriteLine("DeletePerson service is up...");

            ServiceHost modifyPersonService = new ServiceHost(typeof(PersonServices.ModifyPersonService));
            modifyPersonService.Open();
            Console.WriteLine("ModifyPerson service is up...");

            ServiceHost addItemService = new ServiceHost(typeof(AddItem));
            addItemService.Open();
            Console.WriteLine("AddItem service is up...");

            ServiceHost deleteItemService = new ServiceHost(typeof(DeleteItem));
            deleteItemService.Open();
            Console.WriteLine("DeleteItem service is up...");

            ServiceHost subscriptionService = new ServiceHost(typeof(SubscriptionService));
            subscriptionService.Open();
            Console.WriteLine("Subscription service is up...");

            ServiceHost retrieveItemsService = new ServiceHost(typeof(RetrieveItems));
            retrieveItemsService.Open();
            Console.WriteLine("RetrieveItems service is up...");

            ServiceHost loadPersonService = new ServiceHost(typeof(LoadPersonInfo));
            loadPersonService.Open();
            Console.WriteLine("LoadPersonService service is up...");

            ServiceHost modifyItemService = new ServiceHost(typeof(ModifyItem));
            modifyItemService.Open();
            Console.WriteLine("ModifyItem service is up...");

            ServiceHost loadItemService = new ServiceHost(typeof(LoadItem));
            loadItemService.Open();
            Console.WriteLine("LoadIteem service is up...");
            Console.WriteLine("Server is fully up!");
            Console.ReadLine();
        }
    }
}
