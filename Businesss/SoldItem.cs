using System;
using System.Collections.Generic;
using System.Text;

namespace Business
{
    public class SoldItem
    {
        public int Id { get; set; }
        public Product Item { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
