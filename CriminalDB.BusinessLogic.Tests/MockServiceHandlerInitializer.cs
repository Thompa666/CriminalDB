using CriminalDB.BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CriminalDB.DataAccess.Interfaces;

namespace CriminalDB.BusinessLogic.Tests
{
    public class MockServiceHandlerInitializer : IServiceHandlerInitializer
    {
        private MockOffenderRepository repository;

        public MockServiceHandlerInitializer()
        {
            repository = new MockOffenderRepository();
        }

        public IOffenderRepository GetOffenderRepository()
        {
            return repository;
        }
    }
}
