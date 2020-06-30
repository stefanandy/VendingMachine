using System.Threading.Tasks;

namespace Business
{
    public interface IReport
    {
        public  Task Add(SoldItem item);



        public  Task WriteAllItemsSold();


        public  Task WriteItemsSoldLast30Days();


        public  Task WriteItemsSoldLast7Days();


        public  Task WriteItemsSoldLast1Days();



        public  Task WriteTop5SoldItems();
        
    }
}