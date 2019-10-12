using System;

namespace TroydonFitness.Models.Products
{
    public class PersonalTraining
    {
        public string Key { get; internal set; }
        public int PersonalTrainingID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ExperienceLevel { get; set; }
        public TimeSpan WorkoutLength { get; set; }

        public int ProductId { get; set; }
        public Products Produt { get; set; }

    }
}