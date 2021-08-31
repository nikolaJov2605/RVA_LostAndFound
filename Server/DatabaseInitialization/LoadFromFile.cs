using Common;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.DatabaseInitialization
{
    public static class LoadFromFile
    {
        public static List<Person> LoadPeople()
        {
            List<Person> initialPersonList = new List<Person>();
            using (StreamReader sr = new StreamReader(@"C:\Users\nikol\OneDrive\Dokumenti\GitHub\RVA_LostAndFound\Server\Initialization\UserInitialization.txt"))
            {
                while (!sr.EndOfStream)
                {
                    string row = sr.ReadLine();
                    string[] splittedRow = row.Split(',');

                    DateTime dt = DateTime.ParseExact(splittedRow[4], "d/M/yyyy", CultureInfo.InvariantCulture);

                    Role role = Role.ADMIN;
                    if (splittedRow[5] == "ADMIN")
                        role = Role.ADMIN;
                    else
                        role = Role.USER;

                    Person person = new Person(splittedRow[0], splittedRow[1], splittedRow[2], splittedRow[3], dt.ToString(), role);

                    initialPersonList.Add(person);
                }
            }
            return initialPersonList;
        }


        public static List<Item> LoadItems()
        {
            List<Item> retList = new List<Item>();
            using (StreamReader sr = new StreamReader(@"C:\Users\nikol\OneDrive\Dokumenti\GitHub\RVA_LostAndFound\Server\Initialization\ItemInitialization.txt"))
            {
                List<Person> persons = LoadPeople();

                while (!sr.EndOfStream)
                {
                    string row = sr.ReadLine();
                    string[] splittedRow = row.Split(',');

                    DateTime dt = DateTime.ParseExact(splittedRow[0], "d/M/yyyy", CultureInfo.InvariantCulture);
                    Person owner = persons.Find(x => x.Username == splittedRow[4]);
                    Person finder;
                    bool isFound;


                    if (splittedRow[5] == " ")
                    {
                        finder = null;
                    }
                    else
                    {
                        finder = persons.Find(x => x.Username == splittedRow[5]);
                    }

                    if (splittedRow[6] == "TRUE")
                        isFound = true;
                    else
                        isFound = false;

                    Item item = new Item(dt.ToShortDateString(), splittedRow[1], splittedRow[2], splittedRow[3], owner, finder, isFound);

                    retList.Add(item);
                }
            }
            return retList;
        }

    }
}
