using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using CriminalDB.WcfService.DataContract;

namespace CriminalDB.WcfService.Helpers
{
    public class ValidationUtil
    {
        public static bool ValidateRequest(ServiceRequest request, out string errorMessage)
        {
            //Inquirer Email
            if (string.IsNullOrEmpty(request.InquirerEmail))
            {
                errorMessage = "Inquirer email address field can not be empty.";
                return false;
            }
            if (!(new EmailAddressAttribute()).IsValid(request.InquirerEmail))
            {
                errorMessage = "Invalid inquirer email address.";
                return false;
            }

            //MaxRecords
            if (request.MaxRecords <= 0)
            {
                errorMessage = "Max record count can not be less than 1.";
                return false;
            }

            //Age Range
            if (!ValidateRange(request.Age))
            {
                errorMessage = "Age range value does not comply with the expected pattern.";
                return false;
            }

            //Height Range
            if (!ValidateRange(request.Height))
            {
                errorMessage = "Height range value does not comply with the expected pattern.";
                return false;
            }

            //Weight Range
            if (!ValidateRange(request.Weight))
            {
                errorMessage = "Weight range value does not comply with the expected pattern.";
                return false;
            }

            errorMessage = "";
            return true;
        }


        private static bool ValidateRange(string input)
        {
            if (input.IndexOf('-') == -1)
            {
                int val = 0;
                if (!Int32.TryParse(input, out val))
                {
                    return false;
                }
            }
            else
            {
                string[] arr = input.Split('-');
                if (arr.Length != 2)
                {
                    return false;
                }
                int min = 0;
                if (!Int32.TryParse(arr[0], out min))
                {
                    return false;
                }
                int max = 0;
                if (!Int32.TryParse(arr[1], out max))
                {
                    return false;
                }

                if (min > max)
                {
                    return false;
                }
            }
            return true;
        }
    }
}