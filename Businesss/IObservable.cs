using System;
using System.Collections.Generic;
using System.Text;

namespace Business
{
    public interface  IObservable
    {

        public void AddSubscriber(IObserver observer);
        public void RemoveSubscriber(IObserver obsever);
        public void Notify();
    }
}
