namespace Demo.Shared
{
    public interface IReportProvider<out T>
        where T : IReportData
    {
        T Build(string title);
    }
}