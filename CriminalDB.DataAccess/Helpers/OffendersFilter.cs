using CriminalDB.DomainModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CriminalDB.DataAccess.Helpers
{
    public class OffendersFilter
    {
        public static IQueryable<Offender> Query { get; set; }

        public static void ByFirstName(string firstName)
        {
            if (!string.IsNullOrEmpty(firstName))
            {
                Query = from i in Query
                        where i.FirstName.Equals(firstName, StringComparison.OrdinalIgnoreCase)
                        select i;
            }
        }

        public static void ByLastName(string lastName)
        {
            if (!string.IsNullOrEmpty(lastName))
            {
                Query = from i in Query
                        where i.FirstName.Equals(lastName, StringComparison.OrdinalIgnoreCase)
                        select i;
            }
        }

        public static void ByAge(int minAge, int maxAge)
        {
            if (minAge != 0 || maxAge != 0)
            {
                if (minAge != 0 && maxAge == 0)
                {
                    Query = from i in Query
                            let age = DbFunctions.DiffYears(i.DateOfBirth.Value, DateTime.Now)
                            where i.DateOfBirth.HasValue && age == minAge
                            select i;
                }
                else if (minAge == 0 && maxAge != 0)
                {
                    Query = from i in Query
                            let age = DbFunctions.DiffYears(i.DateOfBirth.Value, DateTime.Now)
                            where i.DateOfBirth.HasValue && age == maxAge
                            select i;
                }
                else
                {
                    Query = from i in Query
                            let age = DbFunctions.DiffYears(i.DateOfBirth.Value, DateTime.Now)
                            where i.DateOfBirth.HasValue && age >= minAge && age <= maxAge
                            select i;
                }
            }
        }

        public static void ByHeight(int minHeight, int maxHeight)
        {
            if (minHeight != 0 || maxHeight != 0)
            {
                if (minHeight != 0 && maxHeight == 0)
                {
                    Query = from i in Query
                            where i.Height == minHeight
                            select i;
                }
                else if (minHeight == 0 && maxHeight != 0)
                {
                    Query = from i in Query
                            where i.Height == maxHeight
                            select i;
                }
                else
                {
                    Query = from i in Query
                            where i.Height >= minHeight && i.Height <= maxHeight
                            select i;
                }
            }
        }

        public static void ByWeight(int minWeight, int maxWeight)
        {
            if (minWeight != 0 || maxWeight != 0)
            {
                if (minWeight != 0 && maxWeight == 0)
                {
                    Query = from i in Query
                            where i.Weight == minWeight
                            select i;
                }
                else if (minWeight == 0 && maxWeight != 0)
                {
                    Query = from i in Query
                            where i.Weight == maxWeight
                            select i;
                }
                else
                {
                    Query = from i in Query
                            where i.Weight >= minWeight && i.Weight <= maxWeight
                            select i;
                }
            }
        }

        public static void ByNationality(string nationality)
        {
            if (!string.IsNullOrEmpty(nationality))
            {
                Query = from i in Query
                        where i.Nationality.Equals(nationality, StringComparison.OrdinalIgnoreCase)
                        select i;
            }
        }


        public static void ByGender(string gender)
        {
            if (!string.IsNullOrEmpty(gender))
            {
                Query = from i in Query
                        where i.Gender.Equals(gender, StringComparison.OrdinalIgnoreCase)
                        select i;
            }
        }

        public static void ByCountry(string country)
        {
            if (!string.IsNullOrEmpty(country))
            {
                Query = from i in Query
                        where i.Country.Equals(country, StringComparison.OrdinalIgnoreCase)
                        select i;
            }
        }

        public static void ByCity(string city)
        {
            if (!string.IsNullOrEmpty(city))
            {
                Query = from i in Query
                        where i.City.Equals(city, StringComparison.OrdinalIgnoreCase)
                        select i;
            }
        }
        
        public static void ByMaxRecords(int maxRecords)
        {
            int count = (Query.Count() > maxRecords ? maxRecords : Query.Count());

            Query = (from i in Query
                     orderby i.OffenderID
                     select i).Take(count);

        }
    }
}
