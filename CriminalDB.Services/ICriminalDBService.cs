using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CriminalDB.Services
{
    [ServiceContract]
    public interface ICriminalDBService
    {
        [OperationContract]
        bool Search(ServiceRequest request, out string errorMessage);
    }
}
