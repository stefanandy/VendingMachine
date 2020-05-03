using Businesss;
using System;
using System.Collections.Generic;
using System.Text;


namespace Business
{
    public class Dispenser:IObservable
    {
        private IProductCollection Products;
        private List<IObserver> Subscribers;
        private PaymentTerminal Payment;


        public Dispenser(ProductCollection products, PaymentTerminal payment) {
            Products = products;
            Payment = payment;
            Subscribers = new List<IObserver>();
        }

        public Dispenser(ProductCollection products)
        {
            Products = products;
        }

        public bool DeliverItem(ContainableItem coordinates) 
        {
            Product item= Products.GetItem(coordinates);
            if (item!=null && Payment.VerifyTransaction(item.Price))
            {
                Notify();
                return true;
            }
            return false;
        }

        public bool DeliverItem(int id)
        {
            Product item = Products.GetItem(id);
            if (item != null && Payment.VerifyTransaction(item.Price))
            {
                Notify();
                return true;
            }
            return false;
        }


        public void Notify() {

            foreach (var observer in Subscribers)
            {
                observer.Update();
            }

        }

        public void Add(IObserver observer)
        {
            Subscribers.Add(observer);
        }

        public void Remove(IObserver obsever)
        {
            Subscribers.Remove(obsever);
        }
    }
}
