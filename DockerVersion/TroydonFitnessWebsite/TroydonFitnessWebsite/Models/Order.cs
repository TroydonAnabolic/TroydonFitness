using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TroydonFitnessWebsite.Models.Products;

namespace TroydonFitnessWebsite.Models
{
    public class Order
    {
        // PK
        public int OrderID { get; set; }
        // Optional FKs, it means that orders can have one or none of these
        public int? TrainingRoutineID { get; set; }
        public int? DietID { get; set; }
        public int? SupplementID { get; set; }
        public int? TrainingEquipmentID { get; set; }
        //public int ProductID { get; set; }

        // Navigation properties of all the potential orders details we can have
        public Product Product { get; set; }
        public TrainingRoutine TrainingRoutine { get; set; }
        public Diet Diet { get; set; }
        public Supplement Supplement { get; set; }
        public TrainingEquipment TrainingEquipment { get; set; }
        public ICollection<Cart> CartItems { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }

        // Order Details
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public int NumberOfItemsOrdered { get; set; }

        //public string OrderDetails { get; set; }
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]  // TODO: Fix order number not generating: http://www.kodyaz.com/t-sql/custom-sequence-string-as-sql-identity-column.aspx
        public Guid? OrderNumber{ get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd hh:mm:ss}", ApplyFormatInEditMode = true)]
        [Display(Name = "Order Date")]
        public DateTime OrderDate { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd hh:mm:ss}", ApplyFormatInEditMode = true)]
        [Display(Name = "Order Updated")]
        public DateTime OrderUpdated { get; set; }

        // Purchaser Details
        public string PurchaserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
      //  public int[] OrderImages { get; internal set; }

    }
}
