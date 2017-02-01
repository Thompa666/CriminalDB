using CriminalDB.Web.CriminalDBServiceReference;
using CriminalDB.Web.Helper;
using CriminalDB.Web.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CriminalDB.Web.Tests.Helpers
{
    [TestClass]
    public class MapperTests
    {
        [TestMethod]
        public void Test_Mapper_Result()
        {
            var request = new RequestViewModel { InquirerEmail = "email@email.com", MaxRecords = 10, FirstName = "", LastName = "", Age = "0", Height = "0", Weight = "0", City = "", Country = "", Gender = "", Nationality = "" };
            var serviceRequest = Mapper.MapRequestViewModelToServiceRequest(request);

            Assert.IsInstanceOfType(serviceRequest, typeof(ServiceRequest));
            Assert.AreEqual(request.InquirerEmail, serviceRequest.InquirerEmail);
            Assert.AreEqual(request.MaxRecords, serviceRequest.MaxRecords);
            Assert.AreEqual(request.FirstName, serviceRequest.FirstName);
            Assert.AreEqual(request.LastName, serviceRequest.LastName);
            Assert.AreEqual(request.Age, serviceRequest.Age);
            Assert.AreEqual(request.Height, serviceRequest.Height);
            Assert.AreEqual(request.Weight, serviceRequest.Weight);
            Assert.AreEqual(request.Gender, serviceRequest.Gender);
            Assert.AreEqual(request.Nationality, serviceRequest.Nationality);
            Assert.AreEqual(request.Country, serviceRequest.Country);
            Assert.AreEqual(request.City, serviceRequest.City);
        }
    }
}
