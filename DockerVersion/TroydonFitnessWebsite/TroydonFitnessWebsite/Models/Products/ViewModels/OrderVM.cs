using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TroydonFitnessWebsite.Models.Products.ViewModels
{
    public class OrderVM
    {
        public int OrderID { get; set; }
        public int? ProductID { get; set; }
        public int? TrainingRoutineID { get; set; }
        public int? DietID { get; set; }
        public int? SupplementID { get; set; }
        public int? TrainingEquipmentID { get; set; }

        // Navigation
        public ICollection<Cart> CartItems { get; set; }
        public Product Product { get; set; }
        public TrainingRoutine TrainingRoutine { get; set; }
        public Diet Diet { get; set; }
        public Supplement Supplement { get; set; }
        public TrainingEquipment TrainingEquipment { get; set; }

        // Order Details
        [Display (Name = "Product Name")]
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public int NumberOfItemsOrdered { get; set; }


        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid OrderNumber { get; set; }

        // Customer Details
        public string PurchaserID { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public string Email { get; set; }
        [Display(Name = "Address Line 1")]
        public string AddressLine1 { get; set; }
        [Display(Name = "Address Line 2")]
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string OrderDetails { get; set; }
        public List<byte[]> OrderImages { get; internal set; }
    }
}
