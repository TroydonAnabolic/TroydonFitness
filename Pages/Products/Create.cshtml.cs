using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TroydonFitness.Data;
using TroydonFitness.Models.ProductModel;

namespace TroydonFitness.Pages.Products
{
    public class CreateModel : PageModel
    {
        private readonly TroydonFitness.Data.ProductContext _context;

        public CreateModel(TroydonFitness.Data.ProductContext context)
        {
            _context = context;
        }

        public enum Availability
        {
            Available,
            Unavailable,
            ComingSoon
        }

        public IActionResult OnGet()
        {
        ViewData["PersonalTrainingId"] = new SelectList(_context.Set<PersonalTraining>(), "PersonalTrainingID", "PersonalTrainingID");
            return Page();
        }

        [BindProperty]
        public Product Product { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var emptyProduct = new Product();

            if (await TryUpdateModelAsync<Product>(
                emptyProduct,
                "product",   // Prefix for form value.
                p => p.PersonalTrainingId, p => p.Title, p => p.Description, p => p.Price,
                p => p.Quantity, p => p.HasStock, p => p.ProductAdded))
            {
                _context.Products.Add(emptyProduct);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return Page();
        }
    }
}
