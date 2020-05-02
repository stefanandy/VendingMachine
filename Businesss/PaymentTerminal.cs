using System;
using System.Collections.Generic;
using System.Text;

namespace Business
{
    public class PaymentTerminal
    {
        private double BankNotes;
        private double Coins;
        private double Cash;

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
        public void GiveChange(double price) {
            if (Cash>0)
            {
                double change = Cash - price;
                MoneyInMachine.Coins -= change;
            }
            
        }
    }
}
