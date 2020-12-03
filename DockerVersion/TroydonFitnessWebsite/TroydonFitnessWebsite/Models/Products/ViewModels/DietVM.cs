using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TroydonFitnessWebsite.Pages.Products;

namespace TroydonFitnessWebsite.Models.Products.ViewModels
{
    public class DietVM
    {
        // Primary Keys
        public int DietID { get; set; }

        // Foreign Keys
        public int? PersonalTrainingID { get; set; }
        public PersonalTraining PersonalTraining { get; set; }
        [Display(Name = "Diet Name")]
        public string DietName { get; set; }
        [Required]
        [StringLength(250, MinimumLength = 20, ErrorMessage = "Description needs to be a minimum of 20 characters and a maximum of 250 characters.")]
        public string Description { get; set; }
        public string Allergies { get; set; } // use the select list like

        [Display(Name = "Preferred Food Types")]
        public string PreferredFood { get; set; }// = new List<string>() { "Vegetarian", "Chicken", "Beef", "Eggs", "Nuts", "Other" };
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Comments needs to be a minimum of 20 characters and a maximum of 250 characters.")]
        public string Comments { get; set; }
        //public List<CheckboxListItem> Allergies { get; set; }
    }
}
