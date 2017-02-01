using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CriminalDB.Services;
using CriminalDB.BusinessLogic.Interfaces;
using CriminalDB.Services.Interfaces;

namespace CriminalDB.Service.Tests
{
    [TestClass]
    public class SearchServiceTests
    {
        private CriminalDBService service = null;

        [TestInitialize]
        public void Setup()
        {
            ICriminalDBServiceInitializer initializer = new MockSearchServiceInitializer();
            service = new CriminalDBService(initializer);
        }

        [TestMethod]
        public void Test_Search_With_Valid_Request()
        {
            ServiceRequest request = new ServiceRequest() { InquirerEmail = "email@email.com", MaxRecords = 10, FirstName = "", LastName = "", Age = "0", Gender = "", Height = "0", Weight = "0", Nationality = "", City = "", Country = "" };
            string errorMessage = "";
            bool isPass = service.Search(request, out errorMessage);

            Assert.IsTrue(isPass);
            Assert.AreEqual(0, errorMessage.Length);
        }

        [TestMethod]
        public void Test_Search_With_Invalid_Request()
        {
            ServiceRequest request = new ServiceRequest() { InquirerEmail = "email.com", MaxRecords = 10, FirstName = "", LastName = "", Age = "0", Gender = "", Height = "0", Weight = "0", Nationality = "", City = "", Country = "" };
            string errorMessage = "";
            bool isPass = service.Search(request, out errorMessage);

            Assert.IsFalse(isPass);
            Assert.AreEqual("Invalid inquirer email address.", errorMessage);
        }
    }
}
