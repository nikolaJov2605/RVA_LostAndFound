using Common;
using Database;
using Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.DatabaseInitialization
{
    public class UserInitializer : IDatabaseInitializer
    {
        ILoggingManager loggingManager = new LoggingManager();
        public void InitializeTable()
        {
            List<Person> initialPersonList = LoadFromFile.LoadPeople();

            using (AppDBContext context = new AppDBContext())
            {
                foreach(Person person in initialPersonList)
                {
                    var query = context.Persons.Where(x => x.Username == person.Username).FirstOrDefault<Person>();

                    if (query == null)
                        context.Persons.Add(person);
                }
                context.SaveChanges();

                EventLog eventLog = new EventLog(DateTime.Now, Status.INFO, "All initial users have been loaded to database.");
                loggingManager.LogEvent(eventLog);
            }
        }
    }
}
