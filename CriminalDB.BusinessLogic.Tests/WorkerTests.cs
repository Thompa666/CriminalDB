using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CriminalDB.DataAccess.Interfaces;
using CriminalDB.DomainModels;
using CriminalDB.BusinessLogic.Data;

namespace CriminalDB.BusinessLogic.Tests
{
    [TestClass]
    public class WorkerTests
    {
        private IOffenderRepository repository = null;

        [TestInitialize]
        public void Setup()
        {
            repository = new MockOffenderRepository();
        }

        [TestMethod]
        public void Test_QueryDatabase_Map_Returned_Offender_List_To_Results_List()
        {
            var request = new Request("email@email.com", 100, "", "", 0, 0, null, null, 0, 0, 0, 0, null, null);

            Worker worker = new Worker();
            var results = worker.QueryDatabase(request, repository);
            var result1 = results[0];
            var result2 = results[1];

            Assert.AreEqual(2, results.Count);

            Assert.IsInstanceOfType(result1, typeof(Result));
            Assert.AreEqual(1, result1.ResultID);
            Assert.AreEqual(2, result1.TotalCount);
            Assert.AreEqual("email@email.com", result1.Requester);
            Assert.AreEqual(DateTime.Now.ToShortDateString(), result1.ReportDate.ToShortDateString());
            Assert.IsNotNull(result1.SearchQuery);
            Assert.IsNotNull(result1.Offender);

            Assert.IsInstanceOfType(result2, typeof(Result));
            Assert.AreEqual(2, result2.ResultID);
            Assert.AreEqual(2, result2.TotalCount);
            Assert.AreEqual("email@email.com", result2.Requester);
            Assert.AreEqual(DateTime.Now.ToShortDateString(), result2.ReportDate.ToShortDateString());
            Assert.IsNotNull(result2.SearchQuery);
            Assert.IsNotNull(result2.Offender);
        }

        [TestMethod]
        public void Test_QueryDatabase_GeneratePdfs()
        {
            var request = new Request("email@email.com", 100, "", "", 0, 0, null, null, 0, 0, 0, 0, null, null);

            Worker worker = new Worker();
            var results = worker.QueryDatabase(request, repository);
            var files = worker.GeneratePdfFiles(results);

            Assert.AreEqual(2, files.Count);
        }
    }
}
