using CriminalDB.DataAccess.Helpers;
using CriminalDB.DataAccess.Interfaces;
using CriminalDB.DomainModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CriminalDB.DataAccess.Repositories
{
    public class OffenderRepository : Repository<Offender>, IOffenderRepository
    {
        public OffenderRepository(CriminalDBContext context):base(context)
        {

        }

        public IEnumerable<Offender> Search(Request request)
        {
            IEnumerable<Offender> results = null;

            try
            {
                OffendersFilter.Query = (Context as CriminalDBContext).Offenders.AsQueryable();

                OffendersFilter.ByFirstName(request.FirstName);
                OffendersFilter.ByLastName(request.LastName);
                OffendersFilter.ByAge(request.AgeMin, request.AgeMax);
                OffendersFilter.ByHeight(request.HeightMin, request.HeightMax);
                OffendersFilter.ByWeight(request.WeightMin, request.WeightMax);
                OffendersFilter.ByNationality(request.Nationality);
                OffendersFilter.ByGender(request.Gender);
                OffendersFilter.ByCountry(request.Country);
                OffendersFilter.ByCity(request.City);
                OffendersFilter.ByMaxRecords(request.MaxRecords);

                results = OffendersFilter.Query.ToList();
            }
            catch (Exception e)
            {
                //TODO log the exception
                Trace.TraceError($"[OffenderRepository][Search]: " + e.Message);
            }
            Trace.TraceError($"[OffenderRepository][Search]: ");

            return results;
        }
    }
}
