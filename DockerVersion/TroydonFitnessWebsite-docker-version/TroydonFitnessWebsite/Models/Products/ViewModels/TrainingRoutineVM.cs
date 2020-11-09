using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TroydonFitnessWebsite.Pages.Products;

namespace TroydonFitnessWebsite.Models.Products.ViewModels
{
    public class TrainingRoutineVM
    {
        // Primary Keys
        public int TrainingRoutineID { get; set; }

        // Foreign Keys
        [Required]
        public int PersonalTrainingID { get; set; }

        [Display(Name = "Routine Name")]
        public string RoutineName { get; set; }
        public decimal Price { get; set; }

        public PersonalTraining PersonalTraining { get; set; }
        //Customer can select all options, but its to select their preferred available dates


        // Things to inherit: Title, Price, Quantity, Availability, time added from Product
        // Inherit from Personal Training: PTSession type, experience level
    }
}

