using CriminalDB.BusinessLogic.Interface;
using CriminalDB.Services.Interfaces;
using System;

namespace CriminalDB.Service.Tests
{
    public class MockSearchServiceInitializer : ICriminalDBServiceInitializer
    {
        public IServiceHandler GetServiceHandler()
        {
            return new MockServiceHandler();
        }
    }
}
