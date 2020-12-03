using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TroydonFitnessWebsite.Areas.Identity.Data.Authorization;
using TroydonFitnessWebsite.Data;
using TroydonFitnessWebsite.Models.Products;

namespace TroydonFitnessWebsite.Pages.Products
{
    public class EditModel : PageModel
    {
        private readonly ProductContext _context;

        public EditModel(
            ProductContext context)

        {
            _context = context;
        }

        [BindProperty]
        public Product Product { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Product = await _context.Products.FindAsync(id);

            if (Product == null)
            {
                return NotFound();
            }

            //// authorized users only can view
            //var isAuthorized = await AuthorizationService.AuthorizeAsync(
            //                                   User, Product,
            //                                   ProductOperations.Update);
            //if (!isAuthorized.Succeeded)
            //{
            //    return Forbid();
            //}

            return Page();
        }


        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int id)
        {
            // When you don't have to include related data, FindAsync is more efficient.
            var productToUpdate = await _context.Products.FindAsync(id);

            if (productToUpdate == null)
            {
                return NotFound();
            }


            if (await TryUpdateModelAsync<Product>(
                productToUpdate,
                "product",
                p => p.Title, p => p.ShortDescription, p => p.Price, p => p.Quantity, p => p.Quantity, p => p.HasStock, p => p.LastUpdated))
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return Page();
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.ProductID == id);
        }
    }
}
