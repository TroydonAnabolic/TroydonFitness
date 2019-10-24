using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        [Required]
        [StringLength(50, MinimumLength = 5,
            ErrorMessage = "Title must be between 5 and 50 characters long")]
        [Display(Name = "Product Title")]
        [Column("Title")]
        public string Title { get; set; }

        [Required]
        [MinLength(50, ErrorMessage = "Description posts must be at least 50 characters long")]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Product Description")]
        public string Description { get; set; }

        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        public decimal Quantity { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Product Added Date")]
        public DateTime ProductAdded { get; set; }

        [Display(Name = "Product Stock Availability")]
        public Availability HasStock { get; set; }

        public enum Availability
        {
            Available,
            Unavailable,
            ComingSoon
        }

    }
}
