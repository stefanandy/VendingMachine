
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class Dispenser:IObserver, IReportObservable
    {
        private IProductCollection Products;
        private List<IReport> Reports;
        private bool canDeliver = false;

       
        public Dispenser(IProductCollection products)
        {
            Products = products;
            Reports = new List<IReport>();
        }

        public void AddReport(IReport report)
        {
            Reports.Add(report);
        }

        public async Task<bool> DeliverItem(int Row, int Column) 
        {
            ContainableItem containble = await Products.GetItem(Row,Column);
            if (containble != null && canDeliver == true)
            {
                canDeliver = false;
                SoldItem soldItem = new SoldItem { Item = containble.Item, TimeStamp = DateTime.Now };
                NotifyReport(soldItem);
                return true;
            }
            return false;
        }

        public async Task<bool> DeliverItem(int id)
        {
            ContainableItem containble = await Products.GetItem(id);
            if (containble != null && canDeliver == true)
            {
                canDeliver = false;
                SoldItem soldItem = new SoldItem { Item = containble.Item, TimeStamp = DateTime.Now };
                NotifyReport(soldItem);
                return true;
            }
            return false;
        }

        public void NotifyReport(SoldItem item)
        {
            foreach (var report in Reports)
            {
                report.Add(item);
            }
        }

        public void RemoveReport(IReport report)
        {
            Reports.Remove(report);
        }

        public void Update() {
            canDeliver = true;
        }
      
    }
}
