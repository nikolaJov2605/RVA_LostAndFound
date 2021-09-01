using Front.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Front
{
    public static class LoadLogger
    {
        public static ObservableCollection<EventLogModel> LoadLogHistory()
        {
            ObservableCollection<EventLogModel> retList = new ObservableCollection<EventLogModel>();
            using (StreamReader sr = new StreamReader(@"C:\Users\nikol\OneDrive\Dokumenti\GitHub\RVA_LostAndFound\Logger\AppLog.txt"))
            {
                while(!sr.EndOfStream)
                {
                    string row = sr.ReadLine();
                    string[] splittedRow = row.Split('|');
                    EventLogModel model = new EventLogModel(DateTime.Parse(splittedRow[1]), splittedRow[3], splittedRow[5]);

                    retList.Add(model);
                }
            }
            return retList;
        }
    }
}
