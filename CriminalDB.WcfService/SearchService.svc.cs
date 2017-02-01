using CriminalDB.BusinessLogic;
using CriminalDB.BusinessLogic.Interface;
using CriminalDB.WcfService.DataContract;
using CriminalDB.WcfService.Helpers;
using CriminalDB.WcfService.Interfaces;
using CriminalDB.WcfService.ServiceContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CriminalDB.WcfService
{
    public class SearchService : ISearchService
    {
        private IServiceHandler serviceHandler;

        public SearchService()
        {
            serviceHandler = new ServiceHandler(new ServiceHandlerInitializer());
        }

        public SearchService(ISearchServiceInitializer initializer)
        {
            serviceHandler = initializer.GetServiceHandler();
        }

        public bool Search(ServiceRequest serviceRequest, out string errorMessage)
        {
            bool isPass = ValidationUtil.ValidateRequest(serviceRequest, out errorMessage);
            if (isPass)
            {
                var request = Mapper.MapServiceRequestToRequest(serviceRequest);
                serviceHandler.ServeRequest(request);
            }

            return isPass;
        }
    }
}
