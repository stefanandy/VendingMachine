using System;
using System.Collections.Generic;
using System.Text;

namespace Business
{
    public class PaymentTerminal: IObserver
    {
        private double BankNotes;
        private double Coins;
        private double Cash;
        private double Price;

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

        void UpdateMoney() {
            MoneyInMachine.Coins += Coins;
            MoneyInMachine.BankNotes += BankNotes;
        }
        void ResetMoney() {
            Coins = 0;
            BankNotes = 0;
        }

        public void Update() {
            UpdateMoney();
            GiveChange();
            ResetMoney();
        }
    }
}
