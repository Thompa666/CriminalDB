using CriminalDB.Web.CriminalDBServiceReference;
using CriminalDB.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CriminalDB.Web.Helper
{
    public class Mapper
    {
        public static ServiceRequest MapRequestViewModelToServiceRequest(RequestViewModel model)
        {
            ServiceRequest request = new ServiceRequest
            {
                InquirerEmail = model.InquirerEmail,
                MaxRecords = model.MaxRecords,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Age = model.Age,
                Gender = model.Gender,
                Nationality = model.Nationality,
                Height = model.Height,
                Weight = model.Weight,
                City = model.City,
                Country = model.Country
            };

            return request;
        }
    }
}