using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TroydonFitness.Models.ProductModel
{
    public class Supplement
    {
        // Keys

        public int Id { get; set; }
        //public int CustomizedRoutineID { get; set; }
        public int ProductID { get; set; }

        // Navigation
        public Product Product { get; set; }
        public List<SupplementRoutine> SupplementRoutines { get; set; }
        public IEnumerable<CustomizedRoutine> CustomizedRoutines { get; internal set; }


        // Supplement Details
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required, Display(Name = "Supplement Added Date")]
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
