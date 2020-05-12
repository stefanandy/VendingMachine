using System;
using System.Collections.Generic;
using System.Text;


namespace Business
{
    public interface IProductCollection
    {
        public void Add(ContainableItem item);
        public ContainableItem GetItem(int id);
        public ContainableItem GetItem(int Row, int Column);
        public void Remove(int id);
        public void Remove(int Row, int Column);
        public int Count();
     
    }
}
