using System;
using System.Collections.Generic;
using System.Text;

namespace Business
{
    public interface  IObservable
    {

        public void Add(IObserver observer);
        public void Remove(IObserver obsever);
        public void Notify();
    }
}
