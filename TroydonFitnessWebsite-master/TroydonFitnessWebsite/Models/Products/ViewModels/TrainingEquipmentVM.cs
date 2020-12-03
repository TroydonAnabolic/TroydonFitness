using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TroydonFitnessWebsite.Models.Products.ViewModels
{
    public class TrainingEquipmentVM
    {
        // Primary key
        public int TrainingEquipmentID { get; set; }

        // Foreign keys
        [Required]
        public int ProductID { get; set; }
        // Details 
        [Display(Name = "Equipment Name")]
        public string EquipmentName { get; set; }
        [Required]
        [StringLength(250, MinimumLength = 20, ErrorMessage = "Description needs to be a minimum of 20 characters and a maximum of 250 characters.")]
        public string Description { get; set; }

        // TODO: add image upload

        // Things to inherit: Title, Price, Quantity, Availability, time added from Product
    }
}
