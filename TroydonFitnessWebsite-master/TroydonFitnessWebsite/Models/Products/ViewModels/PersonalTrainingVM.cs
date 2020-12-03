using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;

namespace TroydonFitnessWebsite.Models.Products
{
    public class PersonalTrainingVM
    {
        // Primary keys
        public int PersonalTrainingID { get; set; }

        // Foreign Key (key from classes that it has a one relationship with
        public int ProductID { get; set; }
        [Required]
        [StringLength(250, MinimumLength = 20, ErrorMessage = "Description needs to be a minimum of 20 characters and a maximum of 250 characters.")]
        public string Description { get; set; }
        public string PersonalTrainingName { get; set; }

        [Required]
        [Display(Name = "Routine Length. Input duration in days")]
        public int LengthOfRoutine { get; set; }

        [Required]
        [Display(Name = "Personal Training Session Type")]
        public SessionType PTSessionType { get; set; }

        public enum SessionType
        {
            Strength,
            Hypertrophy,
            Endurance
        }
        [Required]
        [Display(Name = "Difficulty Level")]
        public Difficulty ExperienceLevel { get; set; }

        public enum Difficulty
        {
            Beginner,
            Intermediate,
            Advanced
        }
        public IEnumerable<PersonalTraining> PersonalTrainingSessions { get; set; }
        public Product Product { get; set; }


        [Display(Name = "Personal Training Product Picture")]
        public byte[] PtProductPicture { get; set; } 
    }
}
