using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CriminalDB.DataAccess.Repositories;
using System.Data.Entity;
using CriminalDB.DomainModels;
using System.Linq;
using CriminalDB.DataAccess.Interfaces;

namespace CriminalDB.DataAccess.Tests
{
    [TestClass]
    public class OffenderRepositoryTests
    {
        private IOffenderRepository repository;

        [TestInitialize]
        public void Setup()
        {
            Database.SetInitializer(new CriminalDBInitializer());
            CriminalDBContext context = new CriminalDBContext();
            context.Database.Initialize(true);
            repository = new OffenderRepository(context);
        }

        [TestMethod]
        public void Test_Search_No_Filter()
        {
            var request = new Request("email@email.com", 100, "", "", 0, 0, null, null, 0, 0, 0, 0, null,null);
            var results = repository.Search(request);
            int count = results.Count();

            Assert.AreEqual(2, count);
        }

        [TestMethod]
        public void Test_Search_ByFirstName()
        {
            var request = new Request("email@email.com", 100, "SOPHI", "", 0, 0, null, null, 0, 0, 0, 0, null, null);
            var results = repository.Search(request);
            int count = results.Count();

            Assert.AreEqual(0, count);
        }

        [TestMethod]
        public void Test_Search_ByLastName()
        {
            var request = new Request("email@email.com", 100, "", "PARK", 0, 0, null, null, 0, 0, 0, 0, null, null);
            var results = repository.Search(request);
            int count = results.Count();

            Assert.AreEqual(1, count);
        }

        [TestMethod]
        public void Test_Search_ByGender()
        {
            var request = new Request("email@email.com", 100, "", "", 0, 0, "F", null, 0, 0, 0, 0, null, null);
            var results = repository.Search(request);
            int count = results.Count();

            Assert.AreEqual(0, count);
        }

        [TestMethod]
        public void Test_Search_ByAge_With_Only_Min()
        {
            var request = new Request("email@email.com", 100, "", "", 45, 0, null, null, 0, 0, 0, 0, null, null);
            var results = repository.Search(request);
            int count = results.Count();

            Assert.AreEqual(1, count);
        }

        [TestMethod]
        public void Test_Search_ByAge_With_Only_Max()
        {
            var request = new Request("email@email.com", 100, "", "", 0, 45, null, null, 0, 0, 0, 0, null, null);
            var results = repository.Search(request);
            int count = results.Count();

            Assert.AreEqual(1, count);
        }

        [TestMethod]
        public void Test_Search_ByAge_With_Range()
        {
            var request = new Request("email@email.com", 100, "", "", 40, 48, null, null, 0, 0, 0, 0, null, null);
            var results = repository.Search(request);
            int count = results.Count();

            Assert.AreEqual(1, count);
        }


        [TestMethod]
        public void Test_Search_ByHeight_With_Only_Min()
        {
            var request = new Request("email@email.com", 100, "", "", 0, 0, null, null, 187, 0, 0, 0, null, null);
            var results = repository.Search(request);
            int count = results.Count();

            Assert.AreEqual(1, count);
        }

        [TestMethod]
        public void Test_Search_ByHeight_With_Only_Max()
        {
            var request = new Request("email@email.com", 100, "", "", 0, 0, null, null, 0, 187, 0, 0, null, null);
            var results = repository.Search(request);
            int count = results.Count();

            Assert.AreEqual(1, count);
        }

        [TestMethod]
        public void Test_Search_ByHeight_With_Range()
        {
            var request = new Request("email@email.com", 100, "", "", 0, 0, null, null, 175, 200, 0, 0, null, null);
            var results = repository.Search(request);
            int count = results.Count();

            Assert.AreEqual(1, count);
        }


        [TestMethod]
        public void Test_Search_ByWeight_With_Only_Min()
        {
            var request = new Request("email@email.com", 100, "", "", 0, 0, null, null, 0, 0, 59, 0, null, null);
            var results = repository.Search(request);
            int count = results.Count();

            Assert.AreEqual(1, count);
        }

        [TestMethod]
        public void Test_Search_ByWeight_With_Only_Max()
        {
            var request = new Request("email@email.com", 100, "", "", 0, 0, null, null, 0, 0, 0, 59, null, null);
            var results = repository.Search(request);
            int count = results.Count();

            Assert.AreEqual(1, count);
        }

        [TestMethod]
        public void Test_Search_ByWeight_With_Range()
        {
            var request = new Request("email@email.com", 100, "", "", 0, 0, null, null, 0, 0, 55, 60, null, null);
            var results = repository.Search(request);
            int count = results.Count();

            Assert.AreEqual(1, count);
        }


        [TestMethod]
        public void Test_Search_ByNationality()
        {
            var request = new Request("email@email.com", 100, "", "", 0, 0, null, "British", 0, 0, 0, 0, null, null);
            var results = repository.Search(request);
            int count = results.Count();

            Assert.AreEqual(1, count);
        }


        [TestMethod]
        public void Test_Search_ByCountry()
        {
            var request = new Request("email@email.com", 100, "", "", 0, 0, null, null, 0, 0, 0, 0, "Russia", null);
            var results = repository.Search(request);
            int count = results.Count();

            Assert.AreEqual(0, count);
        }


        [TestMethod]
        public void Test_Search_ByCity()
        {
            var request = new Request("email@email.com", 100, "", "", 0, 0, null, "", 0, 0, 0, 0, null, "Florida");
            var results = repository.Search(request);
            int count = results.Count();

            Assert.AreEqual(1, count);
        }

        [TestMethod]
        public void Test_Search_ByCountry_And_City()
        {
            var request = new Request("email@email.com", 100, "", "", 0, 0, null, "", 0, 0, 0, 0, "America", "Florida");
            var results = repository.Search(request);
            int count = results.Count();

            Assert.AreEqual(1, count);
        }

        [TestMethod]
        public void Test_Search_ByMaxRecords()
        {
            var request = new Request("email@email.com", 1, "", "", 0, 0, "M", "", 0, 0, 0, 0, "", "");
            var results = repository.Search(request);
            int count = results.Count();

            Assert.AreEqual(1, count);
        }
    }
}
