using Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Businesss
{
    public class ProductCollection:IProductCollection
    {
        private  int Row=0;
        private  int Column=0;

        private readonly int COLUMN_MAX = 3;
        private readonly int ROW_MAX = 3;
        private readonly int ZERO=0;

       
        Dictionary<ContainableItem, Product> products;

        public ProductCollection() {
            
            products = new Dictionary<ContainableItem, Product>();
        }

        public void Add(Product item) 
        {
            if (Row < ROW_MAX)
            {
                AddToColumn(item);
            }
            else if (Row==ROW_MAX) 
            {
                throw new System.Exception("There is no more space in the vending machine");
            }
        }

        public void Add(ContainableItem coordinates, Product item) 
        {
            products.Add(coordinates, item);
        }

        public Product GetItem(int id)
        {
            var product = products.Where(x => x.Value.Id.Equals(id))
                        .Select(y=>y.Value)
                        .Single();
            if (product!=null)
            {
                return product;
            }
            throw new System.Exception("Item not found");
        }

        public void Remove(int id)
        {
            var key = products.Where(x => x.Value.Id.Equals(id))
                        .Select(y => y.Key)
                        .Single();
            if (key!=null)
            {
                products.Remove(key);
                return;
            }
            throw new System.Exception("Item not found");
        }
        public void Remove(ContainableItem coordinates)
        {
            products.Remove(coordinates);
        }

        public int Count()
        {
            return products.Count;
        }

        public Product GetItem(ContainableItem coordinates)
        {
            var item = products.Where(x => x.Key.Row== coordinates.Row 
                                    && x.Key.Column== coordinates.Column)
                                    .FirstOrDefault()
                                    .Value;
            return item;
        }


        private void AddToColumn(Product item)
        {
            if (Column < COLUMN_MAX)
            {
                products.Add(new ContainableItem(Row, Column), item);
                Column++;

            }
            else if (Column == COLUMN_MAX)
            {
                Column = ZERO;
                Row++;
                products.Add(new ContainableItem(Row, Column), item);
            }
        }

        
    }
}
