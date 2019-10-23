using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TroydonFitness.Models.ProductModel
{
    public class Product
    {
        // Primary Key
        public int ProductID { get; set; }

        // Foreign Key
        public int PersonalTrainingId { get; set; }

        // Navigation Properties
        public PersonalTraining PersonalTrainingSessions { get; set; }
        public ICollection<Supplement> Supplements { get; set; }
        public List<CustomizedRoutine> CustomizedRoutines { get; set; }
        public ICollection<Diet> Diets { get; set; }
        public ICollection<TrainingEquipment> TrainingEquipments { get; set; }


        // Product Details
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal Quantity { get; set; }
        public Availability HasStock { get; set; }

        public enum Availability
        {
            Available,
            Unavailable,
            ComingSoon
        }

    }
}
