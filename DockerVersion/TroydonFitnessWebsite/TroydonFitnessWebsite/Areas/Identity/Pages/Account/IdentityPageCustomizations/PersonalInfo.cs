using System;
using System.ComponentModel.DataAnnotations;

namespace TroydonFitnessWebsite.Areas.Identity.Pages.Account.IdentityPageCustomizations
{
    public class PersonalInfo
    {
        // Personal Data to be added here if possible
        [DataType(DataType.Text)]
        [Display(Name = "Address Line 1")]
        public string AddressLine1 { get; set; }
        [DataType(DataType.Text)]
        [Display(Name = "Address Line 2")]
        public string AddressLine2 { get; set; }
        [DataType(DataType.Text)]
        public string City { get; set; }
        [DataType(DataType.Text)]
        public string State { get; set; }
        [DataType(DataType.Text)]
        public string Zip { get; set; }

        [DataType(DataType.Date)] //TODO: Add this to personal info page
        [DisplayFormat(DataFormatString = "{0:dd-MM-YYYY}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date Of Birth")]
        public DateTime DateOfBirth { get; set; }

        // BMI Info
        public GenderType Gender { get; set; }
        public enum GenderType
        {
            Male,
            Female,
        }
        public int Age { get; set; }

        public double Height { get; set; }

        public double Weight { get; set; }

        public string ActivityType { get; set; } // consider creating a select list like the sample used in selecting prod in personal training TODO

        public double Bodyfat { get; set; }
    }
}
