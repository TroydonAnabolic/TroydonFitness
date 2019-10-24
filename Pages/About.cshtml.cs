using TroydonFitness.Models.ProductModel.ProductsViewModels;
using TroydonFitness.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TroydonFitness.Models.ProductModel;

namespace TroydonFitness.Pages
{
    public class AboutModel : PageModel
    {
        private readonly ProductContext _context;

        public AboutModel(ProductContext context)
        {
            _context = context;
        }

        public IList<ProductAddedGroup> Products { get; set; }

        public async Task OnGetAsync()
        {
            IQueryable<ProductAddedGroup> data =
                from product in _context.Products
                group product by product.ProductAdded into dateGroup
                select new ProductAddedGroup()
                {
                    ProductAdded = dateGroup.Key,
                    ProductCount = dateGroup.Count()
                };

            Products = await data.AsNoTracking().ToListAsync();
        }
    }
}