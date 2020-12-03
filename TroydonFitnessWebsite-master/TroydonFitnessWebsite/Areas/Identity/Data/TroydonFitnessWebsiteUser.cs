using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace TroydonFitnessWebsite.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the TroydonFitnessWebsiteUser class
    [PersonalData]
    public class TroydonFitnessWebsiteUser : IdentityUser
    {
        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        public string FirstName { get; set; }
        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        public string LastName { get; set; }

        public bool IsAdmin { get; set; }
        public bool IsMasterAdmin { get; set; }
        public DateTime CoolOffDate { get; set; }
        [DisplayFormat(DataFormatString = "{0:d\\:hh\\:mm}", ApplyFormatInEditMode = true)]
        public TimeSpan TimeLeft { get; set; }

        // Begin adding data for personal training facts TODO Consider adding these in update profile page as we should not ask until user is registered and make it optional
        [PersonalData]
        [Column(TypeName = "nvarchar(20)")]
        public string AddressLine1 { get; set;}
        [PersonalData]
        [Column(TypeName = "nvarchar(50)")]
        public string AddressLine2 { get; set; }
        [PersonalData]
        [Column(TypeName = "nvarchar(20)")]
        public string City { get; set; }
        [PersonalData]
        [Column(TypeName = "nchar(3)")]
        public string State { get; set; }
        [PersonalData]
        [Column(TypeName = "nchar(4)")]
        public string Zip { get; set; }
        [PersonalData]
        public DateTime DateOfBirth { get; set; }

        // BMI Info
        [PersonalData]
        public GenderType Gender { get; set; }
        public enum GenderType
        {
            Undefined,
            Male,
            Female,
        }
        [PersonalData]
        public double Height { get; set; }

        [PersonalData]
        public double Weight { get; set; }

        [PersonalData]
        public ActivityTypeOptions ActivityType { get; set; } // consider creating a select list like the sample used in selecting prod in personal training TODO

        public enum ActivityTypeOptions
        {
            Undefined,
            Sedentary,
            LightExercise,
            ModerateExercise,
            HeavyExercise,
            Athlete
        }

        [PersonalData]
        public double Bodyfat { get; set; }
    }
}
