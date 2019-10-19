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
        // Keys
        
        public int SupplementID { get; set; }
        public int CustomizedRoutineID { get; set; }
        public int ProductID { get; set; }

        // Navigation
        public Product Product { get; set; }
        public ICollection<SupplementRoutine> CustomizedRoutines { get; set; }

        // Supplement Details
        public DateTime SupplementAdded { get; internal set; }
        public string SupplementType { get; set; }
        public Availability? SupplementAvailability { get; set; }
        public enum Availability
        {
            Available,
            Unavailable,
            ComingSoon
        }
    }
}