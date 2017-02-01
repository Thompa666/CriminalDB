using CriminalDB.Web.CriminalDBServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CriminalDB.Web.Tests
{
    class MockErrorCriminalDBService : ICriminalDBService
    {
        public SearchResponse Search(SearchRequest request)
        {
            return new SearchResponse(false, "Inquirer email address field can not be empty.");
        }

        public Task<SearchResponse> SearchAsync(SearchRequest request)
        {
            return new Task<SearchResponse>(() => new SearchResponse(false, "Inquirer email address field can not be empty."), new CancellationToken());
        }
    }
}
