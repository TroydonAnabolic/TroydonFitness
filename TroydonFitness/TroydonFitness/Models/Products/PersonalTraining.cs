using System;
using System.Collections.Generic;

namespace TroydonFitness.Models.Products
{
    public class PersonalTraining 
    {
        public string ExperienceLevel { get; set; }
        public TimeSpan WorkoutLength { get; set; }

        IEnumerable<Products> Products { get; set; }

        //public Products Product { get; set; }

    }
}