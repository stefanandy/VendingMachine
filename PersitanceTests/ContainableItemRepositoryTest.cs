using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Business;
using Persistance;
using System.Threading.Tasks;

namespace PersitanceTests
{
    [TestClass]
    public class ContainableItemRepositoryTest
    {
        VendingDbContext Context;
        IContainableItemRepository repository;
        ContainableItem entity;

       
        [TestInitialize]
        public void TestInitialize() {           
            Context = new VendingDbContext();
            repository = new ContainableItemRepository(Context);
            entity= new ContainableItem(0, 0, 1, new Product { Price = 0, Name = "Chips" });

        }

        [TestCleanup]
        public void CleanUp() {
            Context.Dispose();       
        }

       

        [TestMethod]
        public async Task Add_Entity() {
            entity = new ContainableItem(0, 0, 1, new Product { Price = 0, Name = "Chips" });
            await repository.Add(entity);
        }

        [TestMethod]
        public async Task Get_Entity_By_Id() {
            var sameEntity = await repository.GetById(entity.Id);
            Assert.AreEqual(entity.Id, sameEntity.Id);
        }

        [TestMethod]
        public async Task Delete_By_Id() {
            await repository.Delete(entity.Id);
        }
    }
}
