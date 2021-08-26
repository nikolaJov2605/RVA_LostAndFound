using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public abstract class Subject
    {
        public abstract void Register(Observer observer);
        public abstract void Unregister(Observer observer);
        public abstract void NotifyObservers();
    }
}
