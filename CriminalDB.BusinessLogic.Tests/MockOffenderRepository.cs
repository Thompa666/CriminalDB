using CriminalDB.DataAccess.Interfaces;
using CriminalDB.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace CriminalDB.BusinessLogic.Tests
{
    public class MockOffenderRepository : IOffenderRepository
    {
        public void Add(Offender entity)
        {
            throw new NotImplementedException();
        }

        public void AddRange(IEnumerable<Offender> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Offender> Find(Expression<Func<Offender, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Offender Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Offender> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Remove(Offender entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<Offender> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Offender> Search(Request request)
        {
            var offenseKim = new Offense(2, DateTime.Parse("2004-2-17"), "ALACHUA", "012012CF0123", "7840412A", "CRIMINAL", "FT", "GUILTY", "AGGRAVATED BATTERY WITH DEADLY WEAPON");
            var offensePark = new Offense(1, DateTime.Parse("1996-12-4"), "ALACHUA", "012004111CF0", "89313", "FELONY", "FF", "GUILTY", "POSSESSION OF CONTROLLED SUBSTANCE: COCAINE");
            List<Offender> results = new List<Offender>
            {
                new Offender("ANTHONY", "PARK", DateTime.Parse("1972-1-17"), "M", "American", 187, 89, "America", "Florida", "263 W 32nd PLACE APT. A, GAINESVILLE, FL 32608", new List<Offense> { offensePark }),
                new Offender("JONATHEN", "KIM", DateTime.Parse("1968-6-10"), "M", "British", 156, 59, "America", "Washington", "2430 Nouakchott Place,Washington, DC 20521-2430", new List<Offense> { offenseKim })
            };

            return results;
        }
    }
}
