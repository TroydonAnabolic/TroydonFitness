using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TroydonFitness.Models.ProductModel
{
    public class TrainingEquipment
    {
        // Keys
        public int Id { get; set; }
        //public int ProductID { get; set; }

        // Navigation
        public Product Product { get; set; }


        // Details
        public Type EquipmentType { get; set; }

        public enum Type
        {
            Belt,
            Strap,
            Band,
            Hooks
        }
    }
}
