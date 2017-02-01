using CriminalDB.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CriminalDB.DataAccess.Interfaces
{
    public interface IOffenderRepository : IRepository<Offender>
    {
        IEnumerable<Offender> Search(Request request);
    }
}
