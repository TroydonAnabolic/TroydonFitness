using System;
using System.Collections.Generic;
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
        public string RoutineType { get; set; }
        public string RoutineDescription { get; set; }
        public Difficulty DifficultyLevel { get; set; }
        public DateTime RoutineAdded { get; set; }

        // TODO: Display who the routine is customized for by linking to user and making visible only to the user
        //public User UserName { get; set; }

        public enum Difficulty
        {
            Beginner,
            Intermediate,
            Advanced
        }
    }
}
