using System;
using System.Collections.Generic;
using System.Text;
using Businesss;


namespace Business
{
    public interface IProductCollection
    {
        public void Add(Product item);
        public Product GetItem(Product item);
        public void Remove(Product item);
        public int Count();
    }
}
