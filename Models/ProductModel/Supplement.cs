using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TroydonFitness.Models.ProductModel
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
