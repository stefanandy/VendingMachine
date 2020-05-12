using Microsoft.VisualStudio.TestTools.UnitTesting;
using Business;

namespace PersistanceTests
{
    [TestClass]
    public class ProductCollectionTests
    {
        IProductCollection products;
        ContainableItem firstItem;
        ContainableItem secondItem;

        [TestInitialize]
        public void TestInitialize() {
             products= new ProductCollection();
             firstItem = new ContainableItem(0, 0, 0, new Product { Price = 0, Name = "Chips" });
             secondItem = new ContainableItem(0, 0, 1, new Product { Price = 0, Name = "Water" });
        }

        [TestCleanup]
        public void TestCleanUp() {
            products = null;
            firstItem = null;
            secondItem = null;
        }

        [TestMethod]
        public void Add_1_Product()
        {          
            products.Add(firstItem);
           
            Assert.AreEqual(1, products.Count());
        }

        [TestMethod]
        public void Add_2_Products() 
        {          
            products.Add(firstItem);
            products.Add(secondItem);

            Assert.AreEqual(2, products.Count());
        }

        [TestMethod]
        public void Get_Product()
        {
            products.Add(firstItem);
            products.Add(secondItem);

            Assert.AreEqual(secondItem, products.GetItem(secondItem.Id));
        }

        [TestMethod]
        public void Count_Products() 
        {
            products.Add(firstItem);
            products.Add(secondItem);

            Assert.AreEqual(2, products.Count());
        }

        [TestMethod]
        public void Remove_1_Product()
        {          
            products.Add(firstItem);
            products.Add(secondItem);

            products.Remove(secondItem.Id);

            Assert.AreEqual(1, products.Count());
        }

     
    }
}
