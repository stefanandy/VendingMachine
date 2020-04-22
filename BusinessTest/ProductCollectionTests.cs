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
            firstItem.Id = 0;
            secondItem.Name = "Water";
            secondItem.Id = 1;

            products.Add(firstItem);
            products.Add(secondItem);

            Assert.AreEqual(secondItem, products.GetItem(secondItem.Id));
        }

        [TestMethod]
        public void Count_Products() 
        {
            IProductCollection products = new ProductCollection();
            Product firstItem = new Product();
            Product secondItem = new Product();

            firstItem.Name = "Chips";
            firstItem.Id = 0;
            secondItem.Name = "Water";
            secondItem.Id = 1;

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

            firstItem.Name = "Chips";
            firstItem.Id = 0;
            secondItem.Name = "Water";
            secondItem.Id = 1;

            products.Add(firstItem);
            products.Add(secondItem);

            products.Remove(secondItem.Id);

            Assert.AreEqual(1, products.Count());
        }

        [TestMethod]
        public void Test_Containers()
        {
            IProductCollection products = new ProductCollection();
            Product firstItem = new Product();
            Product secondItem = new Product();

            firstItem.Name = "Chips";
            firstItem.Id = 0;
            secondItem.Name = "Water";
            secondItem.Id = 1;

            products.Add(firstItem);
            products.Add(secondItem);

            products.Add(new Product { Name = "Chips" ,Id=2});
            products.Add(new Product { Name = "Water", Id = 3 });

            products.Add(new Product { Name = "Chips", Id = 4 });
            products.Add(new Product { Name = "Water", Id = 5 });

            products.Add(new Product { Name = "Chips", Id = 6 });
            products.Add(new Product { Name = "Water", Id = 7 });
            products.Add(new Product { Name = "Chips", Id = 8 });

          
            Product water = products.GetItem(new ContainableItem(0,1));


            Assert.AreEqual(secondItem.Name, water.Name);
        }
    }
}
