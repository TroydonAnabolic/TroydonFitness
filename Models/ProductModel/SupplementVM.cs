using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TroydonFitness.Models.ProductModel
{
    public class SupplementVM
    {
        public int Id { get; set; }
        public int ProductID { get; set; }
        // Supplement Details
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required, Display(Name = "Supplement Added Date")]
        public DateTime SupplementAdded { get; internal set; }
        public string SupplementType { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 5,
            ErrorMessage = "Title must be between 5 and 50 characters long")]
        [Display(Name = "Product Title")]
        public string ProductTitle { get; set; }

        public Availability? SupplementAvailability { get; set; }
        public decimal Price { get; internal set; }

        public enum Availability
        {
            Available,
            Unavailable,
            ComingSoon
        }
    }
}
