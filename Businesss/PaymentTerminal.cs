using System;
using System.Collections.Generic;
using System.Text;

namespace Business
{
    public class PaymentTerminal: IObservable
    {
        private double BankNotes;
        private double Coins;
        private double Cash;
        private double Price;

        private List<IObserver> Subscribers;

        public PaymentTerminal() {
            Subscribers = new List<IObserver>();
        }

        public void AddCash(double bankNotes)
        {
            BankNotes += bankNotes;
            Cash += bankNotes;
        }

        public void AddCoins(double coins) {
            Coins += coins;
            Cash += coins;
        }

        public bool Pay(double price) {
            Price = price;
            if (PayWithCash())
            {
                if (VerifyCash(price))
                {
                    Notify();
                    return true;
                } 
            }
            if (VerifyCreditCardTransaction(price))
            {
                Notify();
                return true;
            }
            return false;
        }

        private bool VerifyCreditCardTransaction(double price)
        {
           
            return true;
        }

        private bool VerifyCash(double price) {
            if (price> Cash)
            {
                throw new System.Exception("Insuficient funds, add more money");
            }          
            return true;
        }

        private bool PayWithCash()
        {
            return true;
        }
        public void GiveChange() {
            var price = Price;
            if (Cash>0)
            {
                double change = Cash - price;
                MoneyInMachine.Coins -= change;
            }
            
        }
     
        public void AddSubscriber(IObserver subscriber)
        {
            Subscribers.Add(subscriber);
        }

        public void RemoveSubscriber(IObserver subscriber)
        {
            Subscribers.Remove(subscriber);
        }

        public void Notify()
        {
            foreach (var subscriber in Subscribers)
            {
                subscriber.Update();
            }
        }
    }
}
