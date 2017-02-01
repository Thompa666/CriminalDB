using CriminalDB.Web.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using CriminalDB.Web.CriminalDBServiceReference;
using CriminalDB.Web.Models;
using System.ComponentModel.DataAnnotations;

namespace CriminalDB.Web.Tests.Controllers
{
    [TestClass]
    public class SearchControllerTests
    {
        [TestMethod]
        public void Test_Search_Get_Index()
        {
            // Arrange
            SearchController controller = new SearchController(new MockSuccessCriminalDBService());

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.ViewData.ModelState.IsValid);
        }

        [TestMethod]
        public void Test_Search_Post_Index_With_Valid_Data()
        {
            // Arrange
            SearchController controller = new SearchController(new MockSuccessCriminalDBService());
            controller.ModelState.Clear();

            // Act
            var request = new RequestViewModel { InquirerEmail = "email@email.com", MaxRecords = 10, FirstName="", LastName="", Age="0", Height="0", Weight="0", City="", Country="", Gender=null, Nationality="" };
            var result = controller.Index(request) as RedirectToRouteResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Confirmation", result.RouteValues["action"]);
        }

        [TestMethod]
        public void Test_Search_Post_Index_With_Invalid_Data()
        {
            // Arrange
            SearchController controller = new SearchController(new MockErrorCriminalDBService());
            controller.ModelState.Clear();

            // Act
            var request = new RequestViewModel { InquirerEmail = "", MaxRecords = 10, FirstName = "", LastName = "", Age = "0", Height = "0", Weight = "0", City = "", Country = "", Gender = null, Nationality = "" };
            var result = controller.Index(request) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsFalse(result.ViewData.ModelState.IsValid);
        }
    }
}
