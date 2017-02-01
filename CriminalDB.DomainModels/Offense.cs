using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CriminalDB.DomainModels
{
    [Table("Offense")]
    public class Offense
    {
        [Key]
        public int OffenseID { get; set; }
        [ForeignKey("Offender")]
        public int OffenderID { get; set; }
        public Nullable<System.DateTime> CrimeDate { get; set; }
        public string CrimeCountry { get; set; }
        public string CaseNumber { get; set; }
        public string OffenseCode { get; set; }
        public string Category { get; set; }
        public string Degree { get; set; }
        public string Disposition { get; set; }
        public string Description { get; set; }

        public virtual Offender Offender { get; set; }

        public Offense(int offenderId, DateTime crimeDate, string crimeCountry, string caseNumber, string offenseCode, string category, string degree, string disposition, string description)
        {
            OffenderID = offenderId;
            CrimeDate = crimeDate;
            CrimeCountry = crimeCountry;
            CaseNumber = caseNumber;
            OffenseCode = offenseCode;
            Category = category;
            Degree = degree;
            Disposition = disposition;
            Description = description;
        }
    }
}
