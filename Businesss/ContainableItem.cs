
using System;
using System.Collections.Generic;
using System.Text;

namespace Business
{
    public class ContainableItem
    {
       
        public int Row { get; set; }
        public int Column { get; set; }

        public int Id { get; set; }

        public Product Item { get; set; }


        public ContainableItem(int row, int column, int id,Product item)
        {
            Row = row;
            Column = column;
            Id = id;
            Item = item;
        }

        public ContainableItem(int row, int column,Product item)
        {
            Row = row;
            Column = column;
            Item = item;
        }

        public ContainableItem() { }

       
    }
}
