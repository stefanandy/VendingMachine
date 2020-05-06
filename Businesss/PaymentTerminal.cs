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

        public bool VerifyTransaction(double price) {
            Price = price;
            if (PayWithCash())
            {
                return VerifyCash(price);
            }
       
            return VerifyCreditCardTransaction(price);
      
        }

        private bool VerifyCreditCardTransaction(double price)
        {
            Notify();
            return true;
        }

        private bool VerifyCash(double price) {
            if (price> Cash)
            {
                throw new System.Exception("Insuficient funds, add more money");
            }
            Notify();
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
     
        public void Add(IObserver subscriber)
        {
            Subscribers.Add(subscriber);
        }

        public void Remove(IObserver subscriber)
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
