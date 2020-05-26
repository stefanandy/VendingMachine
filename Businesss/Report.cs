using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class Report : IReport
    {
        private readonly ISoldItemRepository Repository;
        private readonly Writer Writer;


        public Report(ISoldItemRepository repository, Writer writer)
        {
            Repository = repository;
            Writer = writer;
        }

        public Report() {
            
        }

        public async Task Add(SoldItem item) {
            await Repository.Add(item);
        }

        public async Task WriteAllItemsSold() {
            var items =await  Repository.GetAll();
            Writer.WriteData(items);
        }
        public async Task WriteItemsSoldLast30Days()
        {
            var items = await Repository.GetSoldLast30Days();
            Writer.WriteData(items);
        }
        public async Task WriteItemsSoldLast7Days()
        {
            var items = await Repository.GetSoldLast7Days();
            Writer.WriteData(items);
        }
        public async Task WriteItemsSoldLast1Days()
        {
            var items = await Repository.GetSoldLast1Days();
            Writer.WriteData(items);
        }

        public async Task WriteTop5SoldItems() {
            var items = await Repository.GetTopFiveSoldItems();
            Writer.WriteData(items);
        }

        public void Update() { 
            
        }


    }
}
