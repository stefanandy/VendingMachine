using System;
using System.Collections.Generic;
using System.Text;

namespace Business
{
    public class ContainableItem
    {
       
        public int Row { get; set; }
        public int Column { get; set; }

        public int Count { get; set; } = 30;

        public ContainableItem(int row, int column)
        {
            Row = row;
            Column = column;
        }

       
    }
}
