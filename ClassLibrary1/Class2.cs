using CriminalDB.DomainModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class MyDbContext : DbContext
    {
        public MyDbContext():base("CriminalDBEntities")
        {
            Database.SetInitializer<MyDbContext>(null);
        }

         public DbSet<Offender> Offenders { get; set; }
        public DbSet<Offense> Offenses { get; set; }
    }
    
}
