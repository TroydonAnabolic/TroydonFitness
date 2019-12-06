using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TroydonFitness.Models.ProductModel;

namespace TroydonFitness.Models
{
    public class DietIndexData
    {
        public IEnumerable<Diet> Diets { get; set; }
        public IEnumerable<CustomizedRoutine> CustomizedRoutines { get; set; }
        public IEnumerable<Supplement> Supplements { get; set; }
    }
}
