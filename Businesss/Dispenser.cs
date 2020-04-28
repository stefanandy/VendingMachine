using Businesss;
using System;
using System.Collections.Generic;
using System.Text;


namespace Business
{
    public class Dispenser
    {
        private IProductCollection Products;
        

        public Dispenser(ProductCollection products) 
        {
            Products = products;
        }

        private Product ExtractItem(ContainableItem coordinates)
        {
            var item = Products.GetItem(coordinates);
            if (item != null)
            {
                return item;
            }
            return null;
        }

        public bool DeliverItem(ContainableItem coordinates) 
        {
            Product item= ExtractItem(coordinates);
           
            return item != null ? true : false;
        }
    }
}
