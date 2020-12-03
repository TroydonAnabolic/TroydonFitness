using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TroydonFitnessWebsite.Models.Products
{
    public class TrainingEquipment
    {
        // Primary key
        public int TrainingEquipmentID { get; set; }

        // Foreign keys
        public int ProductID { get; set; }

        // Navigation (many-to-one with product)
        public Product Product { get; set; }
        public ICollection<Cart> CartItems { get; set; }

        public ICollection<Order> Orders { get; set; }

        //// Details 
        [Display(Name = "Equipment Name")]
        public string EquipmentName { get; set; }
        public string Description { get; set; }

        // TODO: add image upload

        // Things to inherit: Title, Price, Quantity, Availability, time added from Product
    }
}