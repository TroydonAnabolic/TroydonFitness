using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TroydonFitness.Models.ProductModel
{
    public class SupplementVM
    {
        public int Id { get; set; }
        // Supplement Details
        public DateTime SupplementAdded { get; internal set; }
        public string SupplementType { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 5,
            ErrorMessage = "Title must be between 5 and 50 characters long")]
        [Display(Name = "Product Title")]
        public string ProductTitle { get; set; }

        public Availability? SupplementAvailability { get; set; }
        public enum Availability
        {
            Available,
            Unavailable,
            ComingSoon
        }
    }
}
