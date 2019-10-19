﻿using System;
using System.Collections.Generic;

namespace TroydonFitness.Models.Products
{
    public class PersonalTraining 
    {

        public int PersonalTrainingID { get; set; }

        public ICollection<Product> Products { get; set; }

        public string ExperienceLevel { get; set; }
        public TimeSpan WorkoutLength { get; set; }
        public PersonalTraining PersonalTrainingSessions { get; set; }
    }
}