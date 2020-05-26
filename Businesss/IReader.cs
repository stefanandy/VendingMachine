using System;
using System.Collections.Generic;
using System.Text;

namespace Business
{
    public interface IReader
    {
        public List<SoldItem> ReadAll(string filePath);

    }
}
