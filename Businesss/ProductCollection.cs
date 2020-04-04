using Business;
using System;
using System.Collections.Generic;
using System.Text;

namespace Businesss
{
    public class ProductCollection:IProductCollection
    {
        List<Product> products;

        public ProductCollection() {
            products = new List<Product>();
        }

        public void Add(Product item) {
            products.Add(item);
        }

        public Product GetItem(Product item)
        {
            if (products.Contains(item))
            {
                return products.Find(x => x == item);
            }
            throw new System.Exception("Item not found");
        }

        public void Remove(Product item)
        {
            if (products.Contains(item))
            {
                products.Remove(item);
                return;
            }
            throw new System.Exception("Item not found");
        }

        public int Count()
        {
            return products.Count;
        }

    }
}
