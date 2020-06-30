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
        IReport report;
        string filePath = "report.csv";
        Writer writer;
        IReader reader;
        PaymentTerminal payment;

        [TestInitialize]
        public void InitTest()
        {
            
            Context = new VendingDbContext();
            SoldItemRepository = new SoldItemRepository(Context);
            ContainableItemRepository = new ContainableItemRepository(Context);
            writer = new CsvWriter(filePath);
            report = new Report(SoldItemRepository, writer);
            reader = new CsvReader();
            products = new ProductCollection(ContainableItemRepository);
            dispenser = new Dispenser(products);
            payment = new PaymentTerminal();

        }

        [TestCleanup]
        public void TestCleanup() {
            Context.Dispose();
        }

        [TestMethod]
        public async Task Test_Report_CSV() {
           

            var chips = new Product { Name = "Chips", Price = 2.5 };

            payment.AddCash(2);
            payment.AddCoins(0.5);

            payment.AddSubscriber(dispenser);
            payment.Pay(chips.Price);
            dispenser.AddReport(report);
            var item = await dispenser.DeliverItem(0, 0);
            await report.WriteAllItemsSold();

            var itemsFromCsv = reader.ReadAll(filePath);


            var allitems =await  SoldItemRepository.GetAll();

            Assert.AreEqual(allitems.Count,itemsFromCsv.Count);
           
        }
    }
}
