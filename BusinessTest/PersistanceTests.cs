using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Business;
using Persistance;

namespace PersistanceTests
{
    [TestClass]
    public class PersistanceTests
    {
        VendingDbContext Context;
        IContainableItemRepository repository;
        ContainableItem entity;

       
        [TestInitialize]
        public void TestInitialize() {           
            Context = new VendingDbContext();
            repository = new ContainableItemRepository(Context);
            entity= new ContainableItem(0, 0, 1, new Product { Price = 1, Name = "Chips", });
        }

        [TestCleanup]
        public void CleanUp() {
            Context.Dispose();       
        }

       

        [TestMethod]
        public void Add_Entity() {           
            repository.Add(entity);
        }

        [TestMethod]
        public void Get_Entity_By_Id() {
            var sameEntity = repository.GetById(entity.Id);
            Assert.AreEqual(entity.Id, sameEntity.Id);
        }

        [TestMethod]
        public void Delete_By_Id() {
            repository.Delete(entity.Id);
        }
    }
}
