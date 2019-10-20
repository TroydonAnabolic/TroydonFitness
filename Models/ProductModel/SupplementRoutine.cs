using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TroydonFitness.Models.ProductModel
{
    public class SupplementRoutine
    {
        public int Id { get; set; }
        public int SupplementId { get; set; }
        public int CustomizedRoutineId { get; set; }
        public Supplement Supplement { get; set; }
        public CustomizedRoutine CustomizedRoutine { get; set; }
    }
}
