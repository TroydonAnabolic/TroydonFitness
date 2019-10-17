using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;
using TroydonFitness.Models.Products;

namespace TroydonFitness.Models.Products
{
    public class Supplement
    {

        // Primary Key
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SupplementID { get; set; }

        public int ProductID { get; set; }

        public int CustomizedRoutineID { get; set; }


        // TODO: try to add many to many relationship so we will not need to rewrite this code in the products table
        public DateTime SupplementAdded { get; internal set; }

        public string SupplementType { get; set; }
        public Availability? SupplementAvailability { get; set; }

        public enum Availability
        {
            Available,
            Unavailable,
            ComingSoon
        }

        public Products Product { get; set; }

        public ICollection<CustomizedRoutine> CustomizedRoutines { get; set; }
    }
}