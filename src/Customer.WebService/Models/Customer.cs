using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerCRUD.WebService.Models
{
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        [NotMapped]
        public int Age 
        { 
            get { return GetAge(DateOfBirth); }
            set { Age = value; }
        }
        public decimal Height { get; set; }
        public decimal Weight { get; set; }
        public string HairColour { get; set; }

        public static int GetAge(DateTime birthday)
        {
            DateTime reference = DateTime.Today;
            int age = reference.Year - birthday.Year;
            if (reference < birthday.AddYears(age)) age--;

            return age;
        }
    }
}
