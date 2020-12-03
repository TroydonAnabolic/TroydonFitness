using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TroydonFitnessWebsite.Models.Products
{
    // This page only has properties for the customer making orders and only has drop down list
    public class TrainingRoutine
    {

        // Primary Keys
        public int TrainingRoutineID { get; set; }

        // Foreign Keys
        public int PersonalTrainingID { get; set; }

        // Navigation 
        public PersonalTraining PersonalTrainingSession { get; set; }
        public ICollection<Cart> CartItems { get; set; }
        public ICollection<Order> Orders { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }


        // TODO: When updating so it is config to be many to many with training routine
        // public ICollection<Diet> Diets { get; set; }

        // Details
        [Display(Name = "Routine Name")]
        public string RoutineName { get; set; }

      //  public string Price { get; set; }

        // Things to inherit: Title, Price, Quantity, Availability, time added from Product
        // Inherit from Personal Training: PTSession type, experience level
        [StringLength(500, MinimumLength = 0, ErrorMessage = "Comments needs to be a maximum of 500 characters, if you need to send a more detailed description, please email troy@hostgateremail.com")]
        public string Comments { get; set; }
        public string DailyAvailability { get; set; }
        public string Monday { get; set; }
        public string Tuesday { get; set; }
        public string Wednesday { get; set; }
        public string Thursday { get; set; }
        public string Friday { get; set; }
        public string Saturday { get; set; }
        public string Sunday { get; set; }
    }
}