using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TroydonFitness.Models.ProductModel
{
    public class PersonalTraining
    {
        // Keys
        public int PersonalTrainingID { get; set; }

        // Navigation
        public PersonalTraining PersonalTrainingSessions { get; set; }
        public ICollection<Product> Products { get; set; }

        // Details
        public string PTTitle { get; set; }
        public string Description { get; set; }
        public TimeSpan WorkoutLength { get; set; }
        public SessionType PTSessionName { get; set; }

        public enum SessionType
        {
            Strength,
            Hypertrophy,
            Endurance
        }
        public Difficulty ExperienceLevel { get; set; }

        public enum Difficulty
        {
            Beginner,
            Intermediate,
            Advanced
        }
    }
}
