using Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Front.Model
{
    public class EventLogModel
    {
        private DateTime time;
        private string status;
        private string message;

        public EventLogModel(DateTime time, string status, string message)
        {
            this.Time = time;
            this.Status = status;
            this.Message = message;
        }

        public DateTime Time { get => time; set => time = value; }
        public string Status { get => status; set => status = value; }
        public string Message { get => message; set => message = value; }
    }
}
