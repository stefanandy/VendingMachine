
using System;
using System.Collections.Generic;
using System.Text;


namespace Business
{
    public class Dispenser:IObserver
    {
        private IProductCollection Products;
        private bool canDeliver = false;
     
        public Dispenser(ProductCollection products)
        {
            Products = products;
        }

        public bool DeliverItem(int Row, int Column) 
        {
            ContainableItem item= Products.GetItem(Row,Column);
            if (item!=null && canDeliver==true)
            {
                canDeliver = false;
                return true;
            }
            return false;
        }

        public bool DeliverItem(int id)
        {
            ContainableItem item = Products.GetItem(id);
            if (item != null && canDeliver == true)
            {
                canDeliver = false;
                return true;
            }
            return false;
        }

        public void Update() {
            canDeliver = true;
        }
      
    }
}
