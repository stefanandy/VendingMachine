using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business;
using Microsoft.EntityFrameworkCore;

namespace Persistance
{
    public class SoldItemRepository : ISoldItemRepository
    {
        private readonly VendingDbContext Context;

        public SoldItemRepository(VendingDbContext context) {
            Context = context;
        }

        public async Task Add(SoldItem item)
        {
            await Context.SoldItem.AddAsync(item);
            await Context.SaveChangesAsync();
        }

        public async Task<SoldItem> Get(int Id)
        {
            var item = await Context.SoldItem.Include(t => t.Item).FirstOrDefaultAsync(x => x.Id == Id);
            return item;
        }

        public async Task<List<SoldItem>> GetAll()
        {
            var items = await Context.SoldItem.Include(t=>t.Item).Select(x => x).ToListAsync();
            return items;
        }

        public async Task<List<SoldItem>> GetSoldLast30Days() {
            var firstDay = DateTime.Today.AddDays(-30);
            var items = await Context.SoldItem.Include(t => t.Item).Where(x => x.TimeStamp >= firstDay)
                            .ToListAsync();
            return items;
        }
        public async Task<List<SoldItem>> GetSoldLast7Days()
        {
            var firstDay = DateTime.Today.AddDays(-7);
            var items = await Context.SoldItem.Include(t => t.Item).Where(x => x.TimeStamp >= firstDay)
                            .ToListAsync();
            return items;
        }

        public async Task<List<SoldItem>> GetSoldLast1Days()
        {
            var firstDay = DateTime.Today.AddDays(-1);
            var items = await Context.SoldItem.Include(t => t.Item).Where(x => x.TimeStamp >= firstDay)
                            .ToListAsync();
            return items;
        }

        public async Task<List<SoldItem>> GetTopFiveSoldItems() {
            
            var items = await Context.SoldItem
                       .Include(t => t.Item)
                       .GroupBy(i => i)
                       .OrderByDescending(g => g.Count())
                       .Take(5)
                       .Select(g=>g.Key).ToListAsync();

            return items;
        }
    }
}
