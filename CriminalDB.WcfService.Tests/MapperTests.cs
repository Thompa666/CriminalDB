using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CriminalDB.DomainModels;
using CriminalDB.Services;
using CriminalDB.Services.Helpers;

namespace CriminalDB.Service.Tests
{
    [TestClass]
    public class MapperTests
    {
        [TestMethod]
        public void Test_Mapper_With_Non_Range_Inputs()
        {
            ServiceRequest serviceRequest = new ServiceRequest() { InquirerEmail = "email@email.com", MaxRecords = 10, FirstName = "", LastName = "", Age = "50", Gender = "", Height = "150", Weight = "60", Nationality = "", City = "", Country = "" };
            Request request = Mapper.MapServiceRequestToRequest(serviceRequest);

            Assert.AreEqual(serviceRequest.InquirerEmail, request.InquirerEmail);
            Assert.AreEqual(serviceRequest.MaxRecords, request.MaxRecords);
            Assert.AreEqual(serviceRequest.FirstName, request.FirstName);
            Assert.AreEqual(serviceRequest.LastName, request.LastName);
            Assert.AreEqual(50, request.AgeMin);
            Assert.AreEqual(0, request.AgeMax);
            Assert.AreEqual(150, request.HeightMin);
            Assert.AreEqual(0, request.HeightMax);
            Assert.AreEqual(60, request.WeightMin);
            Assert.AreEqual(0, request.WeightMax);
            Assert.AreEqual(serviceRequest.Gender, request.Gender);
            Assert.AreEqual(serviceRequest.Nationality, request.Nationality);
            Assert.AreEqual(serviceRequest.Country, request.Country);
            Assert.AreEqual(serviceRequest.City, request.City);
        }

        [TestMethod]
        public void Test_Mapper_With_Range_Inputs()
        {
            ServiceRequest serviceRequest = new ServiceRequest() { InquirerEmail = "email@email.com", MaxRecords = 10, FirstName = "", LastName = "", Age = "50-55", Gender = "", Height = "150-200", Weight = "60-70", Nationality = "", City = "", Country = "" };
            Request request = Mapper.MapServiceRequestToRequest(serviceRequest);

            Assert.AreEqual(serviceRequest.InquirerEmail, request.InquirerEmail);
            Assert.AreEqual(serviceRequest.MaxRecords, request.MaxRecords);
            Assert.AreEqual(serviceRequest.FirstName, request.FirstName);
            Assert.AreEqual(serviceRequest.LastName, request.LastName);
            Assert.AreEqual(50, request.AgeMin);
            Assert.AreEqual(55, request.AgeMax);
            Assert.AreEqual(150, request.HeightMin);
            Assert.AreEqual(200, request.HeightMax);
            Assert.AreEqual(60, request.WeightMin);
            Assert.AreEqual(70, request.WeightMax);
            Assert.AreEqual(serviceRequest.Gender, request.Gender);
            Assert.AreEqual(serviceRequest.Nationality, request.Nationality);
            Assert.AreEqual(serviceRequest.Country, request.Country);
            Assert.AreEqual(serviceRequest.City, request.City);
        }
    }
}
