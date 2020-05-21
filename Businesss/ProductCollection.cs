using Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business
{
    public class ProductCollection:IProductCollection
    {
      
        private List<ContainableItem> Products;


        public ProductCollection(List<ContainableItem> products) {
            Products = products;
        }

        public ProductCollection() {
            
            Products = new List<ContainableItem>();
        }

        public void Add(ContainableItem item) 
        {
            Products.Add(item);
        }
      

        public ContainableItem GetItem(int id)
        {
            var item = Products.Where(x => x.Id.Equals(id))
                                .Single();
                                
            if (item!=null)
            {
                return item;
            }
            throw new System.Exception("Item not found");
        }

        public void Remove(int id)
        {
            var item = Products.Where(x => x.Id.Equals(id))                 
                        .Single();
            if (item!=null)
            {
                Products.Remove(item);
                return;
            }
            throw new System.Exception("Item not found");
        }
        public void Remove(int Row, int Column)
        {
            var item= Products.Where(x => x.Row == Row && x.Column == Column).Single();

            if (item!=null)
            {
                Products.Remove(item);
                return;
            }
            throw new System.Exception("Item not found");
        }

        public int Count()
        {
            return Products.Count;
        }

        public ContainableItem GetItem( int Row, int Column)
        {
            var item = Products.Where(x => x.Row == Row
                                    && x.Column == Column)
                                    .Single();
                                                            
            return item;
        }

      
    }
}
