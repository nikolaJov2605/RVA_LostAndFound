using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    public class EventLog
    {
        private DateTime time;
        private Status status;
        private string message;

        public DateTime Time { get => time; set => time = value; }
        public Status Status { get => status; set => status = value; }
        public string Message { get => message; set => message = value; }

        public EventLog(DateTime dateTime, Status stat, string eventMessage)
        {
            time = dateTime;
            status = stat;
            message = eventMessage;
        }
    }
}
