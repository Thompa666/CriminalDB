using CriminalDB.BusinessLogic.Interface;

namespace CriminalDB.WcfService.Interfaces
{
    public interface ISearchServiceInitializer
    {
        IServiceHandler GetServiceHandler();
    }
}