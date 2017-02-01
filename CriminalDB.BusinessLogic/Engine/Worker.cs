using CriminalDB.BusinessLogic.Helpers;
using CriminalDB.DataAccess.Interfaces;
using CriminalDB.DomainModels;
using CriminalDB.Service.Pdf;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CriminalDB.BusinessLogic.Data
{
    public class Worker
    {
        public void Run(object state)
        {
            WorkItem item = state as WorkItem;

            List<Result> results = QueryDatabase(item.Request, item.Repository);

            List<string> files = GeneratePdfFiles(results);
        }

        /// <summary>
        /// Queries the database.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="repository">The repository.</param>
        /// <returns></returns>
        public List<Result> QueryDatabase(Request request, IOffenderRepository repository)
        {
            List<Result> output = new List<Result>();
            
            string query = Utility.PopulateSearchQuery(request);
            var offenderList = repository.Search(request);
            int count = offenderList.Count();
            int id = 1;

            Result result = null;
            foreach (var offender in offenderList)
            {
                result = new Result();
                result.ResultID = id++;
                result.TotalCount = count;
                result.Requester = request.InquirerEmail;
                result.ReportDate = DateTime.Now;
                result.SearchQuery = query;
                result.Offender = offender;

                output.Add(result);
            }
            Trace.TraceInformation($"Populating {count} results for query={query}");

            return output;
        }
        
        public List<string> GeneratePdfFiles(List<Result> results)
        {
            var folderPath = ConfigurationManager.AppSettings["TempFolder"];
            PdfUtil pdfEngine = new PdfUtil(folderPath);

            return pdfEngine.GenerateAllPdfFiles(results);
        }

    }
}
