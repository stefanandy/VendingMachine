using Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class ProductCollection:IProductCollection
    {           
        private readonly IContainableItemRepository containableItemRepository;

        public ProductCollection(IContainableItemRepository repository) {
            containableItemRepository = repository;
        }


        public async Task Add(ContainableItem item) 
        {
            await containableItemRepository.Add(item);
        }

        public async Task Add(List<ContainableItem> items) {
            await containableItemRepository.Add(items);
        }
      

        public async Task<ContainableItem> GetItem(int id)
        {
            var item = await containableItemRepository.GetById(id);
                                
            if (item!=null)
            {
                return item;
            }
            throw new System.Exception("Item not found");
        }

        public async Task Remove(int id)
        {
            try
            {
                var item = await containableItemRepository.GetById(id);
                await containableItemRepository.Delete(item.Id);
            }
            catch (Exception)
            {

                throw new System.Exception("Item not found");
            }          
       }
        public async Task Remove(int Row, int Column)
        {
            try
            {
                var item = await containableItemRepository.GetByPosition(Row,Column);
                await containableItemRepository.Delete(Row, Column);
            }
            catch (Exception)
            {

                throw new System.Exception("Item not found");
            }
        }

        public async Task<int> Count()
        {
            return containableItemRepository.Count();
        }

        public async Task<ContainableItem> GetItem( int Row, int Column)
        {
            try
            {
                var item = await containableItemRepository.GetByPosition(Row, Column);
                return item;
            }
            catch (Exception)
            {

                throw new System.Exception("Item not found");
            }
        }

      
    }
}
