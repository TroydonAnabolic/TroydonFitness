using System;
using System.Collections.Generic;

namespace TroydonFitness.Models.Products
{
    public class PersonalTraining 
    {

        public int PersonalTrainingID { get; set; }

        public int ProductID { get; set; }

        public string ExperienceLevel { get; set; }
        public TimeSpan WorkoutLength { get; set; }


        //public Products Product { get; set; }

    }
}