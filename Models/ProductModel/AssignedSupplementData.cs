using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TroydonFitness.Models.ProductModel
{
    public class AssignedSupplementData
    {
        public int SupplementID { get; set; }
        public string SupplementTitle { get; set; }
        public bool Assigned { get; set; }
    }
}
