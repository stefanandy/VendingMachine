
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class Dispenser:IObserver
    {
        private IProductCollection Products;
        private Report Report;
        private bool canDeliver = false;

        public Dispenser(IProductCollection products,Report report)
        {
            Products = products;
            Report = report;
        }
        public Dispenser(IProductCollection products)
        {
            Products = products;
        }

        public async Task<bool> DeliverItem(int Row, int Column) 
        {
            ContainableItem containble = await Products.GetItem(Row,Column);
            if (containble != null && canDeliver == true)
            {
                canDeliver = false;
                SoldItem soldItem = new SoldItem { Item = containble.Item, TimeStamp = DateTime.Now };
                await Report.Add(soldItem);
                return true;
            }
            return false;
        }

        public async Task<bool> DeliverItem(int id)
        {
            ContainableItem containble = await Products.GetItem(id);
            if (containble != null && canDeliver == true)
            {
                canDeliver = false;
                SoldItem soldItem = new SoldItem { Item = containble.Item, TimeStamp = DateTime.Now };
                await Report.Add(soldItem);
                return true;
            }
            return false;
        }

        public void Update() {
            canDeliver = true;
        }
      
    }
}
