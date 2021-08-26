using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class DatabaseSubject : Subject
    {
        private List<Observer> observers;

        public DatabaseSubject()
        {
            observers = new List<Observer>();
        }

        public override void NotifyObservers()
        {
            foreach(Observer o in observers)
            {
                o.Notify(this);
            }
        }

        public override void Register(Observer observer)
        {
            observers.Add(observer);
        }

        public override void Unregister(Observer observer)
        {
            observers.Remove(observer);
        }
    }
}
