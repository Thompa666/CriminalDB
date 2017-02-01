using CriminalDB.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CriminalDB.BusinessLogic.Helpers
{
    public class Utility
    {
        /// <summary>
        /// Populates the search query.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public static string PopulateSearchQuery(Request request)
        {
            string query = "Take top " + request.MaxRecords + " records that matches";
            if (!string.IsNullOrEmpty(request.FirstName))
            {
                query += ", FIRST NAME='" + request.FirstName + "'";
            }
            if (!string.IsNullOrEmpty(request.LastName))
            {
                query += ", LAST NAME='" + request.LastName + "'";
            }
            if (request.AgeMin != 0 || request.AgeMax != 0)
            {
                if (request.AgeMin != 0 && request.AgeMax == 0)
                    query += ", AGE=" + request.AgeMin;
                else if(request.AgeMin == 0 && request.AgeMax != 0)
                    query += ", AGE=" + request.AgeMax;
                else
                    query += ", AGE RANGE=" + request.AgeMin + "-" + request.AgeMax;
            }
            if (request.HeightMin != 0 || request.HeightMax != 0)
            {
                if (request.HeightMin != 0 && request.HeightMax == 0)
                    query += ", HEIGHT=" + request.HeightMin;
                else if(request.HeightMin == 0 && request.HeightMax != 0)
                    query += ", HEIGHT=" + request.HeightMax;
                else
                    query += ", HEIGHT RANGE=" + request.HeightMin + "-" + request.HeightMax;
            }
            if (request.WeightMin != 0 || request.WeightMax != 0)
            {
                if (request.WeightMin != 0 && request.WeightMax == 0)
                    query += ", WEIGHT=" + request.WeightMin;
                else if (request.WeightMin == 0 && request.WeightMax != 0)
                    query += ", WEIGHT=" + request.WeightMax;
                else
                    query += ", WEIGHT RANGE=" + request.WeightMin + "-" + request.WeightMax;
            }
            if (!string.IsNullOrEmpty(request.Nationality))
            {
                query += ", NATIONALITY='" + request.Nationality + "'";
            }
            if (!string.IsNullOrEmpty(request.Gender))
            {
                query += ", SEX=" + (request.Gender == "M" ? "MALE" : "FEMALE");
            }
            if (!string.IsNullOrEmpty(request.Country))
            {
                query += ", COUNTRY='" + request.Country + "'";
            }
            if (!string.IsNullOrEmpty(request.City))
            {
                query += ", CITY='" + request.City + "'";
            }

            return query;
        }
    }
}
