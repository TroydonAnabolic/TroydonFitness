using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TroydonFitnessWebsite.Models.Products
{
    public class Supplement
    {
        // Primary Keys
        public int SupplementID { get; set; }

        // Foreign Key
        public int ProductID { get; set; }
        public int? DietID { get; set; }

        // Navigation
        // many-to-one with the product and Diet
        public Product Product { get; set; }
        [DisplayFormat(NullDisplayText = "No Diet Associated with this")]
        public Diet Diet { get; set; }
        public ICollection<Cart> CartItems { get; set; }

        public ICollection<Order> Orders { get; set; }

        public ICollection<OrderDetail> OrderDetails { get; set; }
        // Supplement can have many orders

        // Supplement Details
        [Display(Name = "Supplement Name")]
        public string SupplementName { get; set; }
        public string Description { get; set; }
        // TODO: Upload Image functionality
    }
}