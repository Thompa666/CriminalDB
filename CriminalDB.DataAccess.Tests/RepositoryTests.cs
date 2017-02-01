using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CriminalDB.DataAccess.Repositories;
using System.Data.Entity;
using System.Linq;
using CriminalDB.DomainModels;
using System.Collections.Generic;
using CriminalDB.DataAccess.Interfaces;

namespace CriminalDB.DataAccess.Tests
{
    [TestClass]
    public class RepositoryTests
    {
        private IRepository<Offender> repository;

        [TestInitialize]
        public void Setup()
        {
            Database.SetInitializer(new CriminalDBInitializer());
            CriminalDBContext context = new CriminalDBContext();
            context.Database.Initialize(true);
            repository = new Repository<Offender>(context);
        }

        [TestMethod]
        public void Test_Repository_Get_All()
        {
            var result = repository.GetAll();
            Assert.IsNotNull(result);

            int count = result.Count();
            Assert.AreEqual(2, count);
        }

        [TestMethod]
        public void Test_Repository_Get_For_Existing_Id()
        {
            var expected = "JONATHEN";

            var offender = repository.Get(2);

            Assert.IsNotNull(offender);
            Assert.AreEqual(expected, offender.FirstName);
        }

        [TestMethod]
        public void Test_Repository_Get_For_None_Existing_Id()
        {
            var offender = repository.Get(3);

            Assert.IsNull(offender);
        }

        [TestMethod]
        public void Test_Repository_Add()
        {
            repository.Add(new Offender("SOPHI", "SKIVOSKI", DateTime.Parse("1988-3-5"), "M", "Russian", 148, 51, "America", "New York", "263 W 32nd PLACE APT. A, GAINESVILLE, FL 32608"));

            var count = repository.GetAll().Count();

            Assert.AreEqual(3, count);
        }

        [TestMethod]
        public void Test_Repository_Add_Range()
        {
            List<Offender> list = new List<Offender>() {
                new Offender("SOPHI1", "SKIVOSKI", DateTime.Parse("1988-3-5"), "M", "Russian", 148, 51, "America", "New York", "263 W 32nd PLACE APT. A, GAINESVILLE, FL 32608"),
                new Offender("SOPHI2", "SKIVOSKI", DateTime.Parse("1988-3-5"), "M", "Russian", 148, 51, "America", "New York", "263 W 32nd PLACE APT. A, GAINESVILLE, FL 32608")
            };
            repository.AddRange(list);

            var count = repository.GetAll().Count();

            Assert.AreEqual(4, count);
        }

        [TestMethod]
        public void Test_Repository_Remove_Existing_Item()
        {
            var offender = repository.Get(1);
            repository.Remove(offender);

            var count = repository.GetAll().Count();

            Assert.AreEqual(1, count);
        }

        [TestMethod]
        public void Test_Repository_Remove_Range_Existing_Items()
        {
            List<Offender> list = repository.Find(i => i.Gender == "M").ToList();

            repository.RemoveRange(list);

            var count = repository.GetAll().Count();

            Assert.AreEqual(0, count);
        }
    }
}
