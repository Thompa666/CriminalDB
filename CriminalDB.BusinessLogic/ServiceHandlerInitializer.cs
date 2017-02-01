using CriminalDB.BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CriminalDB.DataAccess.Interfaces;
using CriminalDB.DataAccess;
using CriminalDB.DataAccess.Repositories;

namespace CriminalDB.BusinessLogic
{
    public class ServiceHandlerInitializer : IServiceHandlerInitializer
    {
        private IOffenderRepository _offenderRepository = null;
        
        public ServiceHandlerInitializer()
        {
            CriminalDBContext context = new CriminalDBContext();
            _offenderRepository = new OffenderRepository(context);
        }

        public IOffenderRepository GetOffenderRepository()
        {
            return _offenderRepository;
        }

    }
}
