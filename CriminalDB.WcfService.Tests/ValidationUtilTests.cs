using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CriminalDB.DomainModels;
using CriminalDB.Services;
using CriminalDB.Services.Helpers;

namespace CriminalDB.Service.Tests
{
    [TestClass]
    public class ValidationUtilTests
    {
        [TestMethod]
        public void Test_ValidateRequest_With_Valid_Request()
        {
            string errorMessage = "";
            ServiceRequest serviceRequest = new ServiceRequest() { InquirerEmail = "email@email.com", MaxRecords = 10, FirstName = "", LastName = "", Age = "50", Gender = "", Height = "150", Weight = "60", Nationality = "", City = "", Country = "" };
            bool state = ValidationUtil.ValidateRequest(serviceRequest, out errorMessage);

            Assert.IsTrue(state);
            Assert.AreEqual(0, errorMessage.Length);
        }

        [TestMethod]
        public void Test_ValidateRequest_With_No_InquirerEmail_In_Request()
        {
            string errorMessage = "";
            ServiceRequest serviceRequest = new ServiceRequest() { InquirerEmail = "", MaxRecords = 10, FirstName = "", LastName = "", Age = "50", Gender = "", Height = "150", Weight = "60", Nationality = "", City = "", Country = "" };
            bool state = ValidationUtil.ValidateRequest(serviceRequest, out errorMessage);

            Assert.IsFalse(state);
            Assert.AreEqual("Inquirer email address field can not be empty.", errorMessage);
        }

        [TestMethod]
        public void Test_ValidateRequest_With_Invalidd_InquirerEmail_In_Request()
        {
            string errorMessage = "";
            ServiceRequest serviceRequest = new ServiceRequest() { InquirerEmail = "email", MaxRecords = 10, FirstName = "", LastName = "", Age = "50", Gender = "", Height = "150", Weight = "60", Nationality = "", City = "", Country = "" };
            bool state = ValidationUtil.ValidateRequest(serviceRequest, out errorMessage);

            Assert.IsFalse(state);
            Assert.AreEqual("Invalid inquirer email address.", errorMessage);
        }

        [TestMethod]
        public void Test_ValidateRequest_With_Zero_MaxRecords_In_Request()
        {
            string errorMessage = "";
            ServiceRequest serviceRequest = new ServiceRequest() { InquirerEmail = "email@email.com", MaxRecords = 0, FirstName = "", LastName = "", Age = "50", Gender = "", Height = "150", Weight = "60", Nationality = "", City = "", Country = "" };
            bool state = ValidationUtil.ValidateRequest(serviceRequest, out errorMessage);

            Assert.IsFalse(state);
            Assert.AreEqual("Max record count can not be less than 1.", errorMessage);
        }
        
        [TestMethod]
        public void Test_ValidateRequest_With_Invalid_Age_In_Request()
        {
            string errorMessage = "";
            ServiceRequest serviceRequest = new ServiceRequest() { InquirerEmail = "email@email.com", MaxRecords = 10, FirstName = "", LastName = "", Age = "a", Gender = "", Height = "150", Weight = "60", Nationality = "", City = "", Country = "" };
            bool state = ValidationUtil.ValidateRequest(serviceRequest, out errorMessage);

            Assert.IsFalse(state);
            Assert.AreEqual("Age range value does not comply with the expected pattern.", errorMessage);
        }

        [TestMethod]
        public void Test_ValidateRequest_With_Invalid_Age_Range_In_Request()
        {
            string errorMessage = "";
            ServiceRequest serviceRequest = new ServiceRequest() { InquirerEmail = "email@email.com", MaxRecords = 10, FirstName = "", LastName = "", Age = "50-30-1", Gender = "", Height = "150", Weight = "60", Nationality = "", City = "", Country = "" };
            bool state = ValidationUtil.ValidateRequest(serviceRequest, out errorMessage);

            Assert.IsFalse(state);
            Assert.AreEqual("Age range value does not comply with the expected pattern.", errorMessage);
        }
    }
}
