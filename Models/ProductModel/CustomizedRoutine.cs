using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TroydonFitness.Models.ProductModel
{
    public class CustomizedRoutine
    {
        // Keys
        public int CustomizedRoutineID { get; set; }
        public int SupplementID { get; set; }
        public int ProductID { get; set; }

        // Navigation 
        public Product Product { get; set; }

        public ICollection<SupplementRoutine> Supplements { get; set; }

        // Details
        public string RoutineType { get; set; }
        public Difficulty DifficultyLevel { get; set; }
        public DateTime RoutineAdded { get; set; }

        public enum Difficulty
        {
            Beginner,
            Intermediate,
            Advanced
        }
    }
}
