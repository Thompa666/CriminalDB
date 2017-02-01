using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CriminalDB.DomainModels
{
    public class Request
    {
        public string InquirerEmail { get; set; }
        public int MaxRecords { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public bool HasAge { get; set; }
        public int AgeMin { get; set; }
        public int AgeMax { get; set; }

        public bool HasHeight { get; set; }
        public int HeightMin { get; set; }
        public int HeightMax { get; set; }

        public bool HasWeight { get; set; }
        public int WeightMin { get; set; }
        public int WeightMax { get; set; }

        public string Nationality { get; set; }
        public string Gender { get; set; }
        public string Country { get; set; }
        public string City { get; set; }

        public Request()
        {

        }

        public Request(string inquirerEmail, int maxRecords, string firstName, string lastName, int ageMin, int ageMax, string gender, string nationality, int heightMin, int heightMax, int weightMin, int weightMax, string country, string city)
        {
            InquirerEmail = inquirerEmail;
            MaxRecords = maxRecords;
            FirstName = firstName;
            LastName = lastName;
            AgeMin = ageMin;
            AgeMax = ageMax;
            Gender = gender;
            Nationality = nationality;
            HeightMin = heightMin;
            HeightMax = heightMax;
            WeightMin = weightMin;
            WeightMax = weightMax;
            Country = country;
            City = city;
        }
    }
}
