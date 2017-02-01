using CriminalDB.BusinessLogic.Data;
using CriminalDB.BusinessLogic.Helpers;
using CriminalDB.BusinessLogic.Interface;
using CriminalDB.BusinessLogic.Interfaces;
using CriminalDB.DataAccess.Interfaces;
using CriminalDB.DomainModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CriminalDB.BusinessLogic
{
    public class ServiceHandler : IServiceHandler
    {
        private IOffenderRepository repository = null;

        public ServiceHandler(IServiceHandlerInitializer initializer)
        {
            repository = initializer.GetOffenderRepository();
        }

        public void ServeRequest(Request request)
        {
            WorkItem item = new WorkItem { Request = request, Repository = repository };
            ThreadPool.QueueUserWorkItem(new WaitCallback((new Worker()).Run), item );
        }

        

        
    }

    
}
