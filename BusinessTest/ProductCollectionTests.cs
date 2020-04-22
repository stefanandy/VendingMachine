using Microsoft.VisualStudio.TestTools.UnitTesting;
using Businesss;
using Business;

namespace BusinessTest
{
    [TestClass]
    public class ProductCollectionTests
    {
        [TestMethod]
        public void Add_1_Product()
        {
            IProductCollection products = new ProductCollection();
            Product firstItem = new Product();
            
            firstItem.Name = "Chips";
            
            products.Add(firstItem);
           
            Assert.AreEqual(1, products.Count());
        }

        [TestMethod]
        public void Add_2_Products() 
        {
            IProductCollection products = new ProductCollection();
            Product firstItem = new Product();
            Product secondItem = new Product();

            firstItem.Name = "Chips";
            secondItem.Name = "Water";

            products.Add(firstItem);
            products.Add(secondItem);

            Assert.AreEqual(2, products.Count());
        }

        [TestMethod]
        public void Get_Product()
        {
            IProductCollection products = new ProductCollection();
            Product firstItem = new Product();
            Product secondItem = new Product();

            firstItem.Name = "Chips";
            secondItem.Name = "Water";

            products.Add(firstItem);
            products.Add(secondItem);

            Assert.AreEqual(secondItem, products.GetItem(secondItem));
        }

        [TestMethod]
        public void Count_Products() 
        {
            IProductCollection products = new ProductCollection();
            Product firstItem = new Product();
            Product secondItem = new Product();

            firstItem.Name = "Chips";
            secondItem.Name = "Water";

            products.Add(firstItem);
            products.Add(secondItem);

            Assert.AreEqual(2, products.Count());
        }

        [TestMethod]
        public void Remove_1_Product()
        {
            IProductCollection products = new ProductCollection();
            Product firstItem = new Product();
            Product secondItem = new Product();

            firstItem.Name = "Chips";
            secondItem.Name = "Water";

            products.Add(firstItem);
            products.Add(secondItem);

            products.Remove(secondItem);

            Assert.AreEqual(1, products.Count());
        }

        [TestMethod]
        public void Test_Containers()
        {
            IProductCollection products = new ProductCollection();
            Product firstItem = new Product();
            Product secondItem = new Product();

            firstItem.Name = "Chips";
            secondItem.Name = "Water";

            products.Add(firstItem);
            products.Add(secondItem);

            products.Add(new Product { Name = "Chips" });
            products.Add(new Product { Name = "Water" });

            products.Add(new Product { Name = "Chips" });
            products.Add(new Product { Name = "Water" });

            products.Add(new Product { Name = "Chips" });
            products.Add(new Product { Name = "Water" });
            products.Add(new Product { Name = "Chips" });
            products.Add(new Product { Name = "Water" });

            products.ContainersPopulation();
            Product water = products.GetItem(new ContainableItem(0,1));


            Assert.AreEqual(secondItem.Name, water.Name);
        }
    }
}
