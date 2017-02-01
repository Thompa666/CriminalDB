using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CriminalDB.BusinessLogic.Helpers;
using CriminalDB.DomainModels;

namespace CriminalDB.BusinessLogic.Tests
{
    [TestClass]
    public class UtilityTests
    { 
        [TestMethod]
        public void Test_Populate_Search_Query_With_One_Filter()
        {
            string expected = "Take top 100 records that matches, FIRST NAME='ANNE'";

            var request = new Request("email@email.com", 100, "ANNE", "", 0, 0, null, null, 0, 0, 0, 0, null, null);
            var query = Utility.PopulateSearchQuery(request);

            Assert.AreEqual(expected, query);
        }

        [TestMethod]
        public void Test_Populate_Search_Query_With_Many_Filters()
        {
            string expected = "Take top 100 records that matches, FIRST NAME='ANNE', AGE=55, SEX=FEMALE";

            var request = new Request("email@email.com", 100, "ANNE", "", 55, 0, "F", null, 0, 0, 0, 0, null, null);
            var query = Utility.PopulateSearchQuery(request);

            Assert.AreEqual(expected, query);
        }

        [TestMethod]
        public void Test_Populate_Search_Query_With_Range_Filters()
        {
            string expected = "Take top 100 records that matches, HEIGHT RANGE=150-165";

            var request = new Request("email@email.com", 100, "", "", 0, 0, null, null, 150, 165, 0, 0, null, null);
            var query = Utility.PopulateSearchQuery(request);

            Assert.AreEqual(expected, query);
        }
    }
}
