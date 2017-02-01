using CriminalDB.DataAccess.Interfaces;
using CriminalDB.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CriminalDB.BusinessLogic.Data
{
    public class WorkItem
    {
        public Request Request { get; set; }
        public IOffenderRepository Repository { get; set; }
    }
}
