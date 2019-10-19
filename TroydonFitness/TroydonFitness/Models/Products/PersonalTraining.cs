using System;
using System.Collections.Generic;

namespace TroydonFitness.Models.Products
{
    public class PersonalTraining 
    {
        // Keys
        public int PersonalTrainingID { get; set; }

        // Navigation
        public PersonalTraining PersonalTrainingSessions { get; set; }
        public ICollection<Product> Products { get; set; }

        // Details
        public string ExperienceLevel { get; set; }
        public TimeSpan WorkoutLength { get; set; }
    }
}