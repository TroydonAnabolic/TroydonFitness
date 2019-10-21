using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TroydonFitness.Models.ProductModel
{
    public class Diet
    {
        // Keys
        public int Id { get; set; }
        //public int ProductID { get; set; }

        // Navigation
        public Product Product { get; internal set; }

        // Details
        public Type DietType { get; set; }

        public enum Type
        {
            looseWeight,
            gainMuscle,
        }
    }
}
