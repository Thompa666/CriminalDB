using CriminalDB.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CriminalDB.BusinessLogic.Interfaces
{
    public interface IServiceHandlerInitializer
    {
        IOffenderRepository GetOffenderRepository();
    }
}
