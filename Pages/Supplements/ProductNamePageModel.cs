using TroydonFitness.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;


namespace TroydonFitness.Pages.Supplements
{
    public class ProductNamePageModel : PageModel
    {
        public SelectList ProductNameSL { get; set; }

        public void PopulateProductsDropDownList(ProductContext _context,
            object selectProduct = null)
        {
            var productQuery = from p in _context.Products
                                   orderby p.Title // Sort by name.
                                   select p;

            ProductNameSL = new SelectList(productQuery.AsNoTracking(),
                        "ProductID", "Title", selectProduct);
        }
    }
}
