
using CriminalDB.Web.CriminalDBServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CriminalDB.Web.Tests
{
    class MockSuccessCriminalDBService : ICriminalDBService
    {
        public SearchResponse Search(SearchRequest request)
        {
            return new SearchResponse(true, "");
        }

        public Task<SearchResponse> SearchAsync(SearchRequest request)
        {
            return new Task<SearchResponse>(() => new SearchResponse(true, ""), new CancellationToken());
        }
    }
}
