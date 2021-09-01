using Front.Model;
using Logger;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Front.ViewModel
{
    public class LoggerViewModel
    {
        public static ObservableCollection<EventLogModel> LogList { get; set; }

        public LoggerViewModel()
        {
            LogList = new ObservableCollection<EventLogModel>(LoadLogger.LoadLogHistory());
        }

    }
}
