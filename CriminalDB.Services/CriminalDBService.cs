using CriminalDB.BusinessLogic;
using CriminalDB.BusinessLogic.Interface;
using CriminalDB.Services.Helpers;
using CriminalDB.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CriminalDB.Services
{
    public class CriminalDBService : ICriminalDBService
    {
        private IServiceHandler serviceHandler;

        public CriminalDBService()
        {
            serviceHandler = new ServiceHandler(new ServiceHandlerInitializer());
        }

        public CriminalDBService(ICriminalDBServiceInitializer initializer)
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
