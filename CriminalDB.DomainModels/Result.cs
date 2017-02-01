using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CriminalDB.DomainModels
{
    public class Result
    {
        public int ResultID { get; set; }
        public int TotalCount { get; set; }
        public string Requester { get; set; }
        public DateTime ReportDate { get; set; }
        public string SearchQuery { get; set; }
        public Offender Offender { get; set; }
    }
}
