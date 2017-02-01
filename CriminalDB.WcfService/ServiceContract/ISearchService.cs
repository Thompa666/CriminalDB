using CriminalDB.WcfService.DataContract;
using System.ServiceModel;

namespace CriminalDB.WcfService.ServiceContract
{
    [ServiceContract]
    public interface ISearchService
    {
        [OperationContract]
        bool Search(ServiceRequest request, out string errorMessage);
    }
}
