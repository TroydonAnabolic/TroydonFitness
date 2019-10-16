using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TroydonFitness.Models.Products
{
    public class CustomizedRoutine 
    {// may need to inherit to retrieve properties from product class
        public int ProductForeignKey { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CustomizedRoutineID { get; set; }

        public ICollection<Supplement> Supplements { get; set; }
    }
}