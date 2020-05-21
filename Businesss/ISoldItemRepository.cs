using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public interface ISoldItemRepository
    {
        public Task Add(SoldItem item);
        public Task<SoldItem> Get(int Id);
        public Task<List<SoldItem>> GetAll();
        public Task<List<SoldItem>> GetSoldLast30Days();
        public Task<List<SoldItem>> GetSoldLast7Days();
        public Task<List<SoldItem>> GetSoldLast1Days();
        public Task<List<SoldItem>> GetTopFiveSoldItems();
    }
}
