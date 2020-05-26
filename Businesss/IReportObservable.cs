namespace Business
{
    public interface IReportObservable
    {
        public void AddReport(IReport report);
        public void RemoveReport(IReport report);

        public void NotifyReport(SoldItem item);
    };

}