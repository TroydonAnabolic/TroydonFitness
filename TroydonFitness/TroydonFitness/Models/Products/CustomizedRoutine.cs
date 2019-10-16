using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TroydonFitness.Models.Products
{
    public class CustomizedRoutine : Products
    {
        public int ProductForeignKey { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CustomizedRoutineID { get; set; }

        public ICollection<Supplement> Supplements { get; set; }
    }
}