using CriminalDB.DomainModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CriminalDB.DataAccess.Tests
{
    public class CriminalDBInitializer : DropCreateDatabaseAlways<CriminalDBContext>
    {
        protected override void Seed(CriminalDBContext context)
        {
            context.Offenders.Add(new Offender("ANTHONY", "PARK", DateTime.Parse("1972-1-17"), "M", "American", 187, 89, "America", "Florida", "263 W 32nd PLACE APT. A, GAINESVILLE, FL 32608"));
            context.Offenders.Add(new Offender("JONATHEN", "KIM", DateTime.Parse("1968-6-10"), "M", "British", 156, 59, "America", "Washington", "2430 Nouakchott Place,Washington, DC 20521-2430"));

            context.Offenses.Add(new Offense(2, DateTime.Parse("2004-2-17"), "ALACHUA", "012012CF0123", "7840412A", "CRIMINAL", "FT", "GUILTY", "AGGRAVATED BATTERY WITH DEADLY WEAPON"));
            context.Offenses.Add(new Offense(1, DateTime.Parse("1996-12-4"), "ALACHUA", "012004111CF0", "89313", "FELONY", "FF", "GUILTY", "POSSESSION OF CONTROLLED SUBSTANCE: COCAINE"));

            base.Seed(context);
        }

    }
}
