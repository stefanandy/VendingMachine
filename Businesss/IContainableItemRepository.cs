using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public interface IContainableItemRepository
    {
        public  Task Add(ContainableItem item);
        public Task Add(List<ContainableItem> items);
        public  Task<ContainableItem> GetById(int id);
        public Task<ContainableItem> GetByPosition(int row, int column);

        public Task<List<ContainableItem>> GetAll();
        public Task Delete(int id);
        public Task Delete(int row, int column);

        public int Count();
        
    }
}
