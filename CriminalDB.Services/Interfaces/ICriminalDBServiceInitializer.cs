using CriminalDB.BusinessLogic.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CriminalDB.Services.Interfaces
{
    public interface ICriminalDBServiceInitializer
    {
        IServiceHandler GetServiceHandler();
    }
}
