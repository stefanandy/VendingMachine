using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public interface IProductCollection
    {
        public Task Add(ContainableItem item);
        public Task Add(List<ContainableItem> items);
        public Task<ContainableItem> GetItem(int id);
        public Task<ContainableItem> GetItem(int Row, int Column);
        public Task Remove(int id);
        public Task Remove(int Row, int Column);
        public Task<int> Count();
     
    }
}
