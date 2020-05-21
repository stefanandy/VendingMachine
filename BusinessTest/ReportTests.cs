using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Business;
using Persistance;
using System.Threading.Tasks;

namespace BusinessTests
{
    [TestClass]
    public class ReportTests
    {
        Dispenser dispenser;
        IContainableItemRepository ContainableItemRepository;
        ISoldItemRepository SoldItemRepository;
        IProductCollection products;
        VendingDbContext Context;
        Report report;
        string filePath = "report.csv";
        CsvWriter writer;
        PaymentTerminal payment;

        [TestInitialize]
        public void InitTest()
        {
            writer = new CsvWriter(filePath);
            Context = new VendingDbContext();
            SoldItemRepository = new SoldItemRepository(Context);
            ContainableItemRepository = new ContainableItemRepository(Context);
            report = new Report(SoldItemRepository,writer);
            products = new ProductCollection(ContainableItemRepository);
            dispenser = new Dispenser(products,report);
            payment = new PaymentTerminal();

        }

        [TestMethod]
        public async Task Test_Report() {
            var chips = new Product { Name = "Chips", Price = 2.5 };

            payment.AddCash(2);
            payment.AddCoins(0.5);

            payment.Add(dispenser);
            payment.Pay(chips.Price);
            var item = await dispenser.DeliverItem(0, 0);
            await report.WriteAllItemsSold();

            Assert.AreEqual(true, item);

        }
    }
}
