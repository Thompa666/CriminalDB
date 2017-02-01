using CriminalDB.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CriminalDB.BusinessLogic.Interface
{
    public interface IServiceHandler
    {
        void ServeRequest(Request request);
    }
}
