using Business;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersistanceTests
{
    [TestClass]
    public class DispenserTests
    {

        ProductCollection products;
        PaymentTerminal payment;
        Product chips;
        Product water;

       

        [TestInitialize]
        public void TestInitialize() {
            products = new ProductCollection();
            payment = new PaymentTerminal();

            chips = new Product { Name = "Chips", Price = 2.5 };
            water = new Product { Name = "Water", Price = 3.5 };

            products.Add(new ContainableItem(0, 0, 0, chips));
            products.Add(new ContainableItem(0, 1, 1, water));
        }

        [TestMethod]
        public void Dispense_Item_TRUE() 
        {
            
            payment.AddCash(2);
            payment.AddCoins(0.5);


            Dispenser dispenser = new Dispenser(products);
            
            payment.Add(dispenser);

            payment.Pay(products.GetItem(0,0).Item.Price);
            var value = dispenser.DeliverItem(0,0);

            Assert.AreEqual(true, value);
        }

        [TestMethod]
        [ExpectedException(typeof(System.Exception))]
        public void Dispense_Item_InsuficientFunds()
        {
            ProductCollection products = new ProductCollection();
            PaymentTerminal payment = new PaymentTerminal();
            Product chips = new Product { Name = "Chips", Price = 2.5 };
            Product water = new Product { Name = "Water", Price = 3.5 };

            products.Add(new ContainableItem(0, 0, 0, chips));
            products.Add(new ContainableItem(0, 1, 1, water));

            payment.AddCash(2);

            Dispenser dispenser = new Dispenser(products);
          
            payment.Add(dispenser);

            payment.Pay(products.GetItem(0).Item.Price);
            var value = dispenser.DeliverItem(0,1);

            Assert.AreEqual(false, value);
        }
    }
}
