using System;
using System.Collections.Generic;
using System.Text;
using Businesss;


namespace Business
{
    public interface IProductCollection
    {
        public void Add(Product item);
        public Product GetItem(int id);
        public Product GetItem(ContainableItem coordinates);
        public void Remove(int id);
        public void Remove(ContainableItem coordinates);
        public int Count();
     
    }
}
