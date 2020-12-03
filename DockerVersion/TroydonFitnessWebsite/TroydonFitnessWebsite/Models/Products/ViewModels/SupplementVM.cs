using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TroydonFitnessWebsite.Models.Products.ViewModels
{
    public class SupplementVM
    {
        public int SupplementID { get; set; }

        // Foreign Key
        [Required]
        public int ProductID { get; set; }
        public int? DietID { get; set; }
        // Supplement Details
        [Display(Name = "Supplement Name")]
        public string SupplementName { get; set; }
        [Required]
        [StringLength(250, MinimumLength = 20, ErrorMessage = "Description needs to be a minimum of 20 characters and a maximum of 250 characters.")]
        public string Description { get; set; }

    }
}
