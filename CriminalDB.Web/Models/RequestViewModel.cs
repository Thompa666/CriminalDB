using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CriminalDB.Web.Models
{
    public class RequestViewModel
    {
        public RequestViewModel()
        {
            MaxRecords = 1;
            Age = "0";
            Height = "0";
            Weight = "0";
            Gender = "";
        }

        [Required(ErrorMessage = "Email Address is required")]
        [Display(Name = "Receiver Email Address *")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string InquirerEmail { get; set; }

        [Required(ErrorMessage = "Maximum No. of Results is required")]
        [Display(Name = "Maximum No. of Results *")]
        public int MaxRecords { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Age Range (years)")]
        [RegularExpression("^([0-9-]+)$", ErrorMessage = "Invalid input! Check the example.")]
        public string Age { get; set; }

        [Display(Name = "Height Range (cm)")]
        [RegularExpression("^([0-9-]+)$", ErrorMessage = "Invalid input! Check the example.")]
        public string Height { get; set; }

        [Display(Name = "Weight Range (kg)")]
        [RegularExpression("^([0-9-]+)$", ErrorMessage = "Invalid input! Check the example.")]
        public string Weight { get; set; }

        [StringLength(50)]
        public string Nationality { get; set; }

        public string Gender { get; set; }


        [StringLength(50)]
        public string Country { get; set; }

        [StringLength(50)]
        public string City { get; set; }
    }
}