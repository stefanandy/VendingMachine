using System;
using System.Collections.Generic;
using System.Text;

namespace Business
{
    public interface Writer
    {
        public void WriteData(List<SoldItem> items);
    }
}
