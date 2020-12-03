using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TroydonFitnessWebsite.Models.Products
{
    public class Product
    {
        // Primary Key
        public int ProductID { get; set; }

        // Navigation Properties
        // ICollextion used for tables that this table has a one-to-many relationship with, e.g one product to many supps 
        public ICollection<Supplement> Supplements { get; set; }
        public ICollection<TrainingEquipment> TrainingEquipmentPurchases { get; set; }
        public ICollection<PersonalTraining> PersonalTrainingSessions { get; set; }

        // Class Product Details 

        public string Title { get; set; }

        public string ShortDescription { get; set; }

        // Below  Details to be passed down to sub classess
        // TODO: Make price quantity and has stock as optional as some items need to be individually priced, update in order too
        [DataType(DataType.Currency)]
        public decimal? Price { get; set; }
        public int? Quantity { get; set; }
        [Display(Name = "Stock Availability")]
        public Availability? HasStock { get; set; }

        public enum Availability
        {
            Available,
            Unavailable,
            ComingSoon
        }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd hh:mm:ss}", ApplyFormatInEditMode = true)]
        [Display(Name = "Last Updated")]
        public DateTime LastUpdated { get; set; } // TODO: when a product price is modified, or a new one is added, we want an auto time stamp updated to the database
        // [NotMapped]
        public bool IsChecked { get; set; }
        // For Admin
        // property Sold (to be auto increment on purchase)

    }
}
