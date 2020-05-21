using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class Report
    {
        private readonly ISoldItemRepository Repository;
        private readonly CsvWriter writer;


        public Report(ISoldItemRepository repository, CsvWriter csvWriter)
        {
            Repository = repository;
            writer = csvWriter;
        }

        public Report() {
            
        }

        public async Task Add(SoldItem item) {
            await Repository.Add(item);
        }

        public async Task WriteAllItemsSold() {
            var items =await  Repository.GetAll();
            writer.WriteData(items);
        }
        public async Task WriteItemsSoldLast30Days()
        {
            var items = await Repository.GetSoldLast30Days();
            writer.WriteData(items);
        }
        public async Task WriteItemsSoldLast7Days()
        {
            var items = await Repository.GetSoldLast7Days();
            writer.WriteData(items);
        }
        public async Task WriteItemsSoldLast1Days()
        {
            var items = await Repository.GetSoldLast1Days();
            writer.WriteData(items);
        }

        public async Task WriteTop5SoldItems() {
            var items = await Repository.GetTopFiveSoldItems();
            writer.WriteData(items);
        }


    }
}
