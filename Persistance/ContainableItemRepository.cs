using Business;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance
{
    public class ContainableItemRepository : Business.IContainableItemRepository
    {
        private readonly VendingDbContext Context;

        public ContainableItemRepository(VendingDbContext context) {
            Context = context;
        }

        public async Task Add(ContainableItem item)
        {
            await Context.ContainbleItem.AddAsync(item);
            await Context.SaveChangesAsync();
        }

        public async Task Delete(int Id)
        {
            var item = await GetById(Id);
            Context.ContainbleItem.Remove(item);
            await Context.SaveChangesAsync();
        }

        public async Task<ContainableItem> GetById(int Id)
        {
            var item = await Context.ContainbleItem.FindAsync(Id);
            if (item!=null)
            {
                return item;
            }
            throw new System.Exception("Item has not been found, Id invalid");
        }

        public async Task<List<ContainableItem>> GetAll()
        {
            var entitys = await Context.ContainbleItem.Select(x => x).ToListAsync();
            return entitys;
        }

        public async Task Add(List<ContainableItem> items)
        {
            foreach (var item in items)
            {
                await Context.ContainbleItem.AddAsync(item);
            }
            await Context.SaveChangesAsync();
        }

        public async Task<ContainableItem> GetByPosition(int row, int column)
        {
            var item = await Context.ContainbleItem.SingleAsync(x => x.Row == row && x.Column == column);
            return item;
        }

        public async Task Delete(int row, int column)
        {
            var item = await GetByPosition(row,column);
            Context.ContainbleItem.Remove(item);
            await Context.SaveChangesAsync();
        }

        public int Count()
        {
            return Context.ContainbleItem.Count();
        }
    }
}
