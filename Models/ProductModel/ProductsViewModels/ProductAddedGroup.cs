using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TroydonFitness.Models.ProductModel.ProductsViewModels
{
    public class ProductAddedGroup
    {
        [DataType(DataType.Date)]
        public DateTime? ProductAdded { get; set; }

        public int ProductCount { get; set; }
    }
}
