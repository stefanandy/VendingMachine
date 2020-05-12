using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public interface IContainableItemRepository
    {
        public  Task Add(ContainableItem item);
        public  Task<ContainableItem> GetById(int id);

        public Task<List<ContainableItem>> GetAll();
        public Task Delete(int id);
    }
}
