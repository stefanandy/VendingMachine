using Business;
using Businesss;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessTest
{
    [TestClass]
    public class DispenserTests
    {
        [TestMethod]
        public void Assing_Product_Collection() 
        {
            ProductCollection products = new ProductCollection();
            Dispenser dispenser = new Dispenser(products);
        }

        [TestMethod]
        public void Dispense_Item_TRUE() 
        {
            ProductCollection products = new ProductCollection();
            PaymentTerminal payment = new PaymentTerminal();
            
            products.Add(new Product { Name = "Chips", Id = 0 , Price=2.5});
            products.Add(new Product { Name = "Water", Id = 1 , Price=3.5});


            payment.AddCash(2);
            payment.AddCoins(0.5);


            Dispenser dispenser = new Dispenser(products,payment);

            var value = dispenser.DeliverItem(new ContainableItem(0, 0));

            Assert.AreEqual(true, value);
        }
    }
}
