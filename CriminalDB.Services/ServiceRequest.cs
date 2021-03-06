﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CriminalDB.Services
{
    [DataContract]
    public class ServiceRequest
    {
        [DataMember]
        public string InquirerEmail { get; set; }
        [DataMember]
        public int MaxRecords { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public string Age { get; set; }
        [DataMember]
        public string Height { get; set; }
        [DataMember]
        public string Weight { get; set; }
        [DataMember]
        public string Nationality { get; set; }
        [DataMember]
        public string Gender { get; set; }
        [DataMember]
        public string Country { get; set; }
        [DataMember]
        public string City { get; set; }
    }
}
