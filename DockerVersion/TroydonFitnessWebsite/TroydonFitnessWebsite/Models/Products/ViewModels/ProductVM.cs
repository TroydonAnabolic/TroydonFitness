using System;
using System.ComponentModel.DataAnnotations;

namespace TroydonFitnessWebsite.Models.Products
{
    public class ProductVM
    {
        public int ProductID { get; set; }

        // Class Product Details 
        [Required]
        [RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$", ErrorMessage = "Title must start with an upper case char, and contain only alphanumeric characters")] //test if modify to use numbers too work
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Product title needs to be a minimum of 2 characters and a maximum of 50 characters.")]
        [Display(Name = "Product Title")]
        public string Title { get; set; }
        [Required]
        [StringLength(150, MinimumLength = 2, ErrorMessage = "Description needs to be a minimum of 2 characters and a maximum of 150 characters.")]
        [Display(Name = "Short Description")]
        public string ShortDescription { get; set; }

        // Below  Details to be passed down to sub classess
        [Required]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public Availability HasStock { get; set; }

        public enum Availability
        {
            Available,
            Unavailable,
            ComingSoon
        }
        [Required]
        [DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Last Updated")]
        public DateTime LastUpdated { get; set; } // TODO: when a product price is modified, or a new one is added, we want an auto time stamp updated to the database

    }
}
