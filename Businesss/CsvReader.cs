using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Business
{
    public class CsvReader : IReader
    {
        public List<SoldItem> ReadAll(string filePath)
        {

            List<SoldItem> soldItems = File.ReadAllLines(filePath)
                                           .Skip(1)
                                           .Select(v => FromCsv(v))
                                           .ToList();
            return soldItems;
        }

        private SoldItem FromCsv(string csvLine) {
            string[] values = csvLine.Split(',');
            SoldItem soldItem = new SoldItem();
            Product product = new Product();
            product.Name = Convert.ToString(values[0]);
            product.Price = Convert.ToDouble(values[1]);
            soldItem.Item = product;
            soldItem.TimeStamp = Convert.ToDateTime(values[2]);
            
            return soldItem;
        }
    }
}
