using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CriminalDB.DomainModels
{
    [Table("Offender")]
    public class Offender
    {

        [Key]
        public int OffenderID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Nullable<System.DateTime> DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Nationality { get; set; }
        public Nullable<int> Height { get; set; }
        public Nullable<int> Weight { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        
        [NotMapped]
        public Nullable<int> Age
        {
            get
            {
                if (DateOfBirth.HasValue)
                    return DateTime.Now.Year - DateOfBirth.Value.Year;
                else
                    return null;
            }
        }
        
        public virtual ICollection<Offense> Offenses { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Offender"/> class.
        /// </summary>
        public Offender()
        {
            this.Offenses = new HashSet<Offense>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Offender"/> class.
        /// </summary>
        /// <param name="firstName">The first name.</param>
        /// <param name="lastName">The last name.</param>
        /// <param name="dateOfBirth">The date of birth.</param>
        /// <param name="gender">The gender.</param>
        /// <param name="nationality">The nationality.</param>
        /// <param name="height">The height.</param>
        /// <param name="weight">The weight.</param>
        /// <param name="country">The country.</param>
        /// <param name="city">The city.</param>
        /// <param name="address">The address.</param>
        /// <param name="offenses">The offenses.</param>
        public Offender(string firstName, string lastName, DateTime dateOfBirth, string gender, string nationality, int height, int weight, string country, string city, string address, ICollection<Offense> offenses = null)
        {
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            Gender = gender;
            Nationality = nationality;
            Height = height;
            Weight = weight;
            Country = country;
            City = city;
            Address = address;
            Offenses = offenses == null ? new HashSet<Offense>() : offenses;
        }
        
    }
}
