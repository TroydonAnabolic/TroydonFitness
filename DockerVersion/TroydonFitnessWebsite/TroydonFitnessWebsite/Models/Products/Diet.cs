using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TroydonFitnessWebsite.Models.Products
{
    public class Diet
    {
        // Primary Keys
        public int DietID { get; set; }
        // Foreign Keys
        public int PersonalTrainingID { get; set; }
        public int? OrderID { get; set; }

        // Navigation
        // needs to have one personal training session
        public PersonalTraining PersonalTrainingSession { get; set; }

        // can have one or many Supplements and training routines
        [DisplayFormat(NullDisplayText = "No Supplement is included in this diet")]
        public ICollection<Supplement> Supplements { get; set; }
        public ICollection<Cart> CartItems { get; set; }
        public ICollection<Order> Orders { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }



        // TODO: When updating so it is config to be many to many with training routine
        // public ICollection<TrainingRoutine> TrainingRoutines { get; set; }
        [Display(Name = "Diet Name")]
        public string DietName { get; set; }
        public string Description { get; set; }
        public string Allergies { get; set; } // convert from list to string in the page model class or in the page class

        [Display(Name = "Preferred Food Types")]
        public string PreferredFood { get; set; }  // convert from list to string in the page model class or in the page class

        [StringLength(500, MinimumLength = 0, ErrorMessage = "Comments needs to be a maximum of 500 characters, if you need to send a more detailed description, please email troy@hostgateremail.com")]
        [DisplayFormat(NullDisplayText = "No Comment added")]
        public string Comments { get; set; }
    }
}