using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TroydonFitness.Models.ProductModel
{
    public class CustomizedRoutine
    {
        // Keys
        public int Id { get; set; }
        //public int SupplementID { get; set; }
        public int ProductID { get; set; }

        // Navigation 
        public Product Product { get; set; }

        public ICollection<SupplementRoutine> SupplementRoutines { get; set; }

        // Details
        [Required]
        [Display(Name = "Routine Type")]
        [StringLength(50)]
        public string RoutineType { get; set; }

        [Required]
        [MinLength(50, ErrorMessage = "Description posts must be at least 50 characters long")]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Routine Description")]
        public string RoutineDescription { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Routine Added Date")]
        public DateTime RoutineAdded { get; set; }

        // Routine props to describe what the routine entails (DO not show in Index, just details and create[delete if needed])
        [Display(Name = "Difficulty Level")]
        public Difficulty DifficultyLevel { get; set; }

        public enum Difficulty
        {
            Beginner,
            Intermediate,
            Advanced
        }

        [Required]
        public string Exercise { get; set; }

        [Required,Display(Name ="Muscle Group")]
        public string MuscleGroup { get; set; }

        [Required, Display(Name = "Equipment")]
        public string Equipment { get; set; }

        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:hh\\:mm\\:ss} hours.", ApplyFormatInEditMode = true)]
        [Display(Name = "Workout Duration Time")]
        public TimeSpan WorkoutDuration { get; set; }
        public int Sets { get; set; }
        public int Reps { get; set; }

        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:mm\\:ss} minutes.", ApplyFormatInEditMode = true)]
        [Display(Name = "Rest Time")]
        public TimeSpan Rest { get; set; }

        [Required, Display(Name = "Day")]
        public Days DayOfTheWeek { get; set; }

        public enum Days
        {
        Sunday, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday
        }

        public string ImagePath { get; set; }
        public IFormFile Image { get; set; }
        // TODO: Display who the routine is customized for by linking to user and making visible only to the user
        //public User UserName { get; set; }
    }
}
