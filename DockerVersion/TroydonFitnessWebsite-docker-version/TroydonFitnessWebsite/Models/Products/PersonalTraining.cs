using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TroydonFitnessWebsite.Models.Products
{
    public class PersonalTraining
    {
        // Primary keys
        public int PersonalTrainingID { get; set; }

        // Foreign Key (key from classes that it has a one relationship with
        public int ProductID { get; set; }

        // Navigation
        // PT can have one product
        public Product Product { get; set; }

        // One personal training session can only have one diet and training routine associated to that session
        public ICollection<Diet> Diets { get; set; }
        public ICollection<TrainingRoutine> TrainingRoutine { get; set; }
        public ICollection<Cart> Cart { get; set; }

        public string Description { get; set; }

        // Details to be passed down to sub classess
        [Display(Name = "Personal Training Session")]
        public string PersonalTrainingName { get; set; }

        // [Display(Name = "Routine Length")] TODO: If the user is not admin user then display name to not show full details. Also implement count down timer to email user every week how much time for routine to finish
        [Required]
        [Display(Name = "Routine Length. Input duration in days")]
        public int LengthOfRoutine { get; set; }

        [Display(Name = "Personal Training Session Type")]
        public SessionType PTSessionType { get; set; }

        public enum SessionType
        {
            Strength,
            Hypertrophy,
            Endurance
        }
        [Display(Name = "Difficulty Level")]
        public Difficulty ExperienceLevel { get; set; }

        public enum Difficulty
        {
            Beginner,
            Intermediate,
            Advanced
        }

        [Display(Name = "Personal Training Product Picture")]
        public byte[] PtProductPicture { get; set; }
        public bool IsFeatured { get; internal set; }
    }
}