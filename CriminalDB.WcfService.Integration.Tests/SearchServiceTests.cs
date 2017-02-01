using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ServiceModel;
using System.Threading;
using CriminalDB.Services;
using CriminalDB.WcfService.Integration.Tests.CriminalDBServiceReference;

namespace CriminalDB.Service.Integration.Tests
{
    [TestClass]
    public class SearchServiceTests
    {
        private static ServiceHost host;
        private CriminalDBServiceClient client;

        [ClassInitialize]
        public static void ClassSetup(TestContext ctx)
        {
            host = new ServiceHost(typeof(CriminalDBService));
            host.Open();
        }
        
        [TestMethod]
        public void Test_Search_For_Valid_Request()
        {
            client = new CriminalDBServiceClient("local");
            client.Open();
            
            string errorMessage = string.Empty;
            var request = new CriminalDB.Services.ServiceRequest()
            {
                InquirerEmail = "email@email.com",
                MaxRecords = 10,
                FirstName = "",
                LastName = "",
                Age = "50-55",
                Gender = "",
                Height = "150-200",
                Weight = "60-70",
                Nationality = "",
                City = "",
                Country = ""
            };
            bool isPass = client.Search(request, out errorMessage);

            Assert.IsTrue(isPass);
            Assert.AreEqual(0, errorMessage.Length);
        }


        [TestMethod]
        public void Test_Search_For_Invalid_Request()
        {
            client = new CriminalDBServiceClient("local");
            client.Open();

            string errorMessage = string.Empty;
            var request = new CriminalDB.Services.ServiceRequest()
            {
                InquirerEmail = "",
                MaxRecords = 10,
                FirstName = "",
                LastName = "",
                Age = "50-55",
                Gender = "",
                Height = "150-200",
                Weight = "60-70",
                Nationality = "",
                City = "",
                Country = ""
            };
            bool isPass = client.Search(request, out errorMessage);

            Assert.IsFalse(isPass);
            Assert.AreNotEqual(0, errorMessage.Length);
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            host.Close();
        }
    }
}
