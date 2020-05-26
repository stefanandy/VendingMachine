using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Business
{
    public class CsvWriter:Writer
    {
        private readonly string  filePath;

        public CsvWriter(string filepath) {
            filePath = filepath;
        }

        public void WriteData(List<SoldItem> items) {
            using (var writer = new StreamWriter( File.Open(filePath, System.IO.FileMode.Append) ) )
            {
                foreach (var item in items)
                {
                    var name = item.Item.Name;
                    var price = item.Item.Price;
                    var soldOn = item.TimeStamp;
                    var line = string.Format("{0},{1},{2}", name, price, soldOn);
                    writer.WriteLine(line);
                }
                writer.Flush();
            }
        }
    }
}
