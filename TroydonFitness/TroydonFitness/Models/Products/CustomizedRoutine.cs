using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TroydonFitness.Models.Products
{
    public class CustomizedRoutine 
    {// may need to inherit to retrieve properties from product class
        public CustomizedRoutine()
        {
        }

       // [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CustomizedRoutineID { get; set; }
        public int SupplementID { get; set; }
        public int ProductID { get; set; }
        public ICollection<Supplement> Supplements { get; set; }
        public string RoutineType { get; set; }
        public Difficulty DifficultyLevel { get; set; }
        public DateTime RoutineAdded { get; set; }
        public Product Product { get; internal set; }

        public enum Difficulty
        {
            Beginner,
            Intermediate,
            Advanced
        }
    }
}