using Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Businesss
{
    public class ProductCollection:IProductCollection
    {
        List<Product> products;
        Dictionary<ContainableItem, Product> containers;

        public ProductCollection() {
            products = new List<Product>();
            containers = new Dictionary<ContainableItem, Product>();
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

        public Product GetItem(ContainableItem itemCoordinates)
        {
            return containers.Where(x => x.Key.Row==itemCoordinates.Row 
                                    && x.Key.Column==itemCoordinates.Column)
                                    .FirstOrDefault()
                                    .Value;   
        }

        public void ContainersPopulation()
        {
            int counter =0;
            for (int i = 0; i < Math.Sqrt(products.Count)-1;i++)
            {
                for (int j = 0; j < Math.Sqrt(products.Count)-1; j++)
                {
                    containers.Add(new ContainableItem(i, j), products[counter]);
                    counter++;
                }
            }
        }
    }
}
