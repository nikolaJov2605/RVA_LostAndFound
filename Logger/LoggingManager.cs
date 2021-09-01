using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    public class LoggingManager : ILoggingManager
    {
        public void LogEvent(EventLog eventLog)
        {
            string path = @"C:\Users\nikol\OneDrive\Dokumenti\GitHub\RVA_LostAndFound\Logger\AppLog.txt";

            using (StreamWriter sw = File.AppendText(path))
            {
                string row = String.Format("OPERATION EXECUTED: Time: {0}, Status: {1}, Message: {2}.", eventLog.Time, eventLog.Status, eventLog.Message);

                sw.WriteLine(row);
            }
        }
    }
}
