using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using CriminalDB.DomainModels;

namespace CriminalDB.DataAccess
{
    public class CriminalDBContext : DbContext
    {
        public CriminalDBContext()
            : base("CriminalDBEntities")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public virtual DbSet<Offender> Offenders { get; set; }
        public virtual DbSet<Offense> Offenses { get; set; }
    }
}
