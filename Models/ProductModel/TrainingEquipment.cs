using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TroydonFitness.Models.ProductModel
{
    public class TrainingEquipment
    {
        // Keys
        public int Id { get; set; }
        public int DietID { get; set; }


        // Navigation
        public Product Product { get; set; }
        public Diet Diet { get; set; }

        // Details
        [StringLength(50)]
        [Display(Name = "Equipment Brand")]
        public string Brand { get; set; }

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
