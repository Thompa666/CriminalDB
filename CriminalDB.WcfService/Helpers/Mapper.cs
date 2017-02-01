using CriminalDB.DomainModels;
using CriminalDB.WcfService.DataContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CriminalDB.WcfService.Helpers
{
    public class Mapper
    {
        public static Request MapServiceRequestToRequest(ServiceRequest serviceRequest)
        {
            int ageMin, ageMax, heightMin, heightMax, weightMin, weightMax;

            ConvertRange(serviceRequest.Age, out ageMin, out ageMax);
            ConvertRange(serviceRequest.Height, out heightMin, out heightMax);
            ConvertRange(serviceRequest.Weight, out weightMin, out weightMax);

            Request request = new Request()
            {
                InquirerEmail = serviceRequest.InquirerEmail,
                MaxRecords = serviceRequest.MaxRecords,
                FirstName = serviceRequest.FirstName,
                LastName = serviceRequest.LastName,
                Nationality = serviceRequest.Nationality,
                Gender = serviceRequest.Gender,
                AgeMin = ageMin,
                AgeMax = ageMax,
                HeightMin = heightMin,
                HeightMax = heightMax,
                WeightMin = weightMin,
                WeightMax = weightMax,
                Country = serviceRequest.Country,
                City = serviceRequest.City
            };

            return request;
        }

        private static void ConvertRange(string input, out int min, out int max)
        {
            min = 0;
            max = 0;

            if (input.IndexOf('-') == -1)
            {
                Int32.TryParse(input, out min);
            }
            else
            {
                string[] arr = input.Split('-');
                if (arr.Length == 2)
                {
                    Int32.TryParse(arr[0], out min);
                    Int32.TryParse(arr[1], out max);
                }
            }
        }
    }
}