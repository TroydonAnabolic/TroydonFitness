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
            Beginner, Intermediate, Advanced
        }

        // Nullable with ? so add exercises does not have to be listed
        // Try to Use DisplayNameFor => MuscleGroups.Muscle to see if it can be reused or if need to create Muscle Group 1, 2, 3 ..20
        [Display(Name = "Exercise 1")]
        public Exercises? Exercise1 { get; set; }
        [Display(Name = "Exercise 2")]
        public Exercises? Exercise2 { get; set; }
        [Display(Name = "Exercise 3")]
        public Exercises? Exercise3 { get; set; }
        [Display(Name = "Exercise 4")]
        public Exercises? Exercise4 { get; set; }
        [Display(Name = "Exercise 5")]
        public Exercises? Exercise5 { get; set; }
        [Display(Name = "Exercise 6")]
        public Exercises? Exercise6 { get; set; }
        [Display(Name = "Exercise 7")]
        public Exercises? Exercise7 { get; set; }
        [Display(Name = "Exercise 8")]
        public Exercises? Exercise8 { get; set; }
        [Display(Name = "Exercise 9")]
        public Exercises? Exercise9 { get; set; }
        [Display(Name = "Exercise 10")]
        public Exercises? Exercise10 { get; set; }
        [Display(Name = "Exercise 11")]
        public Exercises? Exercise11 { get; set; }
        [Display(Name = "Exercise 12")]
        public Exercises? Exercise12 { get; set; }
        [Display(Name = "Exercise 13")]
        public Exercises? Exercise13 { get; set; }
        [Display(Name = "Exercise 14")]
        public Exercises? Exercise14 { get; set; }
        [Display(Name = "Exercise 15")]
        public Exercises? Exercise15 { get; set; }

        public enum Exercises
        {
            // Calves
            [Display(Name = "---Calves---")]
            CALVES,
            [Display(Name = "Standing Calf Raise")] StandingCalfRaise, [Display(Name = "Seated Calf Raise")] SeatedCalfRaise,
            // Quadriceps
            [Display(Name = "---Quadriceps---")]
            QUADRICEPS,
            Squat, [Display(Name = "Leg Press")] LegPress, Lunge, [Display(Name = "Leg Extension")] LegExtension, [Display(Name = "Single Leg Extension")] SingleLegExtension, [Display(Name = "Hack Squat")] HackSquat,

            // Hamstrings
            [Display(Name = "---Hamstrings---")]
            HAMSTRINGS,
            [Display(Name = "Seated Leg Curl")] SeatedLegCurl, [Display(Name = "Standing Leg Curl")] StandingLegCurl, [Display(Name = "Romanian Deadlift")] RomanianDeadlift,

            // Glutues
            [Display(Name = "---Glutes---")]
            GLUTES,
            [Display(Name = "Glute Ham Raises")] GluteHamRaises, [Display(Name = "Glute Bridge")] GluteBridge, [Display(Name = "Glute Raises")] GluteRaises, [Display(Name = "Glute Kickbacks")] GluteKickbacks,

            // Hips
            [Display(Name = "---Hips---")]
            HIPS,
            [Display(Name = "Hip Adductor")] HipAdductor, [Display(Name = "Hip Abductor")] HipAbductor, [Display(Name = "Leg Raises")] LegRaises,

            // Lower Back
            [Display(Name = "---Lower Back---")]
            LOWERBACK,
            Deadlift, Hyperextension,

            // Lats
            [Display(Name = "---Upper Back---")]
            LATS,
            [Display(Name = "Pull Ups")] PullUps, Rows, [Display(Name = "Pull Down")] PullDown, 

            //Abdominals
            [Display(Name = "---Abdominals---")]
            ABDOMINALS,
            Crunches, [Display(Name = "Russian Twist")] RussianTwist,

            // Pectorals
            [Display(Name = "---Pectorals---")]
            PECTORALS,
            [Display(Name = "Bench Press")] BenchPress, [Display(Name = "Chest fly")] ChestFly, [Display(Name = "Push Ups")] PushUps,
            // DELTOIDS
            [Display(Name = "---Deltoids---")]
            DELTOIDS,
            [Display(Name = "Upright Row")] UprightRow, [Display(Name = "Shoulder Press")] ShoulderPress, [Display(Name = "Shoulder Fly")] ShoulderFly, [Display(Name = "Lateral Raise")] LtaeralRaise,

            // Triceps
            [Display(Name = "---Triceps---")]
            TRICEPS,
            Pushdown, [Display(Name = "Tricep Extension")] TricepExtension,

            // Biceps
            [Display(Name = "---Biceps---")]
            BICEPS,
            [Display(Name = "Bicep Curl")] BicepCurl, [Display(Name = "Single Arm Bicep Curl")] SingleArmBicepCurl, 

            // Forearms
            [Display(Name = "---Forearms---")]
            FOREARMS,
            [Display(Name = "Forearm Curl")] ForearmCurl, [Display(Name = "Farmers Walk")] FarmerWalk,

            // Trapezius
            [Display(Name = "---Trapezius---")]
            TRAPEZIUS,
            Shrugs,

            // Cardio
            [Display(Name = "---Cardio---")]
            CARDIO,
            Running, Biking, Climbing, Rowing
        }

        // Stretches
        [Display(Name = "Stretch 1")]
        public MuscleGroups? Stretch1 { get; set; }
        [Display(Name = "Stretch 2")]
        public MuscleGroups? Stretch2 { get; set; }
        [Display(Name = "Stretch 3")]
        public MuscleGroups? Stretch3 { get; set; }
        [Display(Name = "Stretch 4")]
        public MuscleGroups? Stretch4 { get; set; }
        [Display(Name = "Stretch 5")]
        public MuscleGroups? Stretch5 { get; set; }


        [Display(Name = "Muscle Group")]
        public MuscleGroups MuscleGroup { get; set; }

        public enum MuscleGroups
        {
            Calves, Quadriceps, Hamstrings, Gluteus, Hips, [Display(Name = "Lower Back")] LowerBack, [Display(Name = "Upper Back")] UpperBack, Abdominals
        }

        [Display(Name = "Equipment Used")]
        public Equipment EquipmentUsed { get; set; }

        public enum Equipment
        {
            Barbell, Dumbbell, 
            [Display(Name = "Tread Mill")] TreadMill, [Display(Name = "Spin Bike")] SpinBike, Elliptical, StepMill, [Display(Name = "Rowing Machine")] RowingMachine
        }

        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:hh\\:mm\\:ss} hours.", ApplyFormatInEditMode = true)]
        [Display(Name = "Workout Duration Time")]
        public TimeSpan WorkoutDuration { get; set; }

        // Specify Sets, Reps, Rest Time, TUT using a customized template to copy paste -- later create many to many relationship to add exercise class to show link
        [Required, DataType(DataType.MultilineText)]
        public string ExerciseDetails { get; set; }

        public MuscleGroups? Monday{ get; set; }
        public MuscleGroups? Tuesday { get; set; }
        public MuscleGroups? Wednesday { get; set; }
        public MuscleGroups? Thursday { get; set; }
        public MuscleGroups? Friday { get; set; }
        public MuscleGroups? Saturday { get; set; }
        public MuscleGroups? Sunday { get; set; }


        [DataType(DataType.ImageUrl)]
        public string ImagePath { get; set; }

     //   public IFormFile Image { get; set; }

        // TODO: Display who the routine is customized for by linking to user and making visible only to the user
        //public User UserName { get; set; }
    }
}
