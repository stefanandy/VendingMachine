﻿using Business;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Persistance;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessTests
{
    [TestClass]
    public class DispenserTests
    {

        ProductCollection products;
        PaymentTerminal payment;
        Product chips;
        Product water;
        VendingDbContext context;
        IContainableItemRepository repository;
       

        [TestInitialize]
        public void  TestInitialize() {
            context = new VendingDbContext();
            repository = new ContainableItemRepository(context);
            products = new ProductCollection(repository);
            payment = new PaymentTerminal();

            chips = new Product { Name = "Chips", Price = 2.5 };
            water = new Product { Name = "Water", Price = 3.5 };
        }

        [TestMethod]
        public async Task Dispense_Item_TRUE() 
        {
            await products.Add(new ContainableItem(0, 0, chips));
            await products.Add(new ContainableItem(0, 1, water));

            payment.AddCash(3);
            payment.AddCoins(0.5);


            Dispenser dispenser = new Dispenser(products);
            
            payment.AddSubscriber(dispenser);
            var item = await products.GetItem(0, 1);
            payment.Pay(item.Item.Price);
            var value = await dispenser.DeliverItem(0,1);

            Assert.AreEqual(true, value);
        }

        [TestMethod]
        [ExpectedException(typeof(System.Exception))]
        public async Task Dispense_Item_InsuficientFunds()
        {
            

            payment.AddCash(2);

            Dispenser dispenser = new Dispenser(products);
          
            payment.AddSubscriber(dispenser);
            var item = await products.GetItem(0, 1);
            payment.Pay(item.Item.Price);
            var value = dispenser.DeliverItem(0,1);

           
        }
    }
}
