using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class ServerObserver : Observer
    {
        public override void Notify(Subject subject)
        {
            // poziv servisa za dobavljanje podataka iz baze
            throw new NotImplementedException();
        }
    }
}
