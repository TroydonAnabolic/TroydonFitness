using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TroydonFitness.Models.ProductModel
{
    public class ProductVM
    {
        //public int PersonalTrainingId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal Quantity { get; set; }
        public Availability HasStock { get; set; }

        public enum Availability
        {
            Available,
            Unavailable,
            ComingSoon
        }
    }
}
