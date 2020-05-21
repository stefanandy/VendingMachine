using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Persistance;
using Business;
using System.Threading.Tasks;

namespace PersitanceTests
{
    [TestClass]
    public class SoldItemRepositoryTests
    {
        VendingDbContext context;
        ISoldItemRepository repository;
        IContainableItemRepository containableItemRepository;

        [TestInitialize]
        public void InitTests() {
            context = new VendingDbContext();
            repository = new SoldItemRepository(context);
            containableItemRepository = new ContainableItemRepository(context);
        }

        [TestMethod]
        public async Task Test_Add() {
            var item = await containableItemRepository.GetByPosition(0, 0);
            var soldItem = new SoldItem { Item = item.Item, TimeStamp = DateTime.Now };
            await repository.Add(soldItem);
        }

    }
}
