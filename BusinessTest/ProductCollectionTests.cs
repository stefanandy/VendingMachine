using Microsoft.VisualStudio.TestTools.UnitTesting;
using Business;
using Persistance;
using Moq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;


namespace BusinessTests
{
    [TestClass]
    public class ProductCollectionTests
    {
        IProductCollection products;
        IContainableItemRepository repository;
        ContainableItem firstItem;
        ContainableItem secondItem;
        VendingDbContext dbContext;
        

        [TestInitialize]
        public void TestInitialize() {
            dbContext = new VendingDbContext();    
            repository = new ContainableItemRepository(dbContext);
            products= new ProductCollection(repository);
            firstItem = new ContainableItem(0, 0, new Product { Price = 0, Name = "Chips" });
            secondItem = new ContainableItem(0, 0, new Product { Price = 0, Name = "Water" });
        }

        [TestCleanup]
        public void TestCleanUp() {
            products = null;
            firstItem = null;
            secondItem = null;
        }

        [TestMethod]
        public async Task Add_1_Product()
        {          
            await products.Add(firstItem);           
            var entity = await products.GetItem(1);
            Assert.AreEqual(firstItem.Id,entity.Id);
        }

        [TestMethod]
        public async Task Add_2_Products() 
        {          
            await products.Add(secondItem);
            var count = await products.Count();
            Assert.AreEqual(2, count);
        }

        [TestMethod]
        public async Task Get_Product()
        {
            var secondProduct = await products.GetItem(3);
            Assert.AreEqual(3, secondProduct.Id);
        }

        [TestMethod]
        public async Task Count_Products() 
        {
            var count = await products.Count();
            Assert.AreEqual(2, count);
        }

        [TestMethod]
        public async Task Remove_1_Product()
        {          
            await products.Remove(2);
            var count = await products.Count();
            Assert.AreEqual(1, count);
        }

     
    }
}
