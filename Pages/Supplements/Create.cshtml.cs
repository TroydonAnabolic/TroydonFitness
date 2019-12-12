using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TroydonFitness.Data;
using TroydonFitness.Models.ProductModel;

namespace TroydonFitness.Pages.Supplements
{
    public class CreateModel : ProductNamePageModel
    {
        private readonly ProductContext _context;

        public CreateModel(ProductContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            PopulateProductsDropDownList(_context);
            return Page();
        }

        [BindProperty]
        public Supplement Supplement { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            var emptySupplement = new Supplement();

            if (await TryUpdateModelAsync<Supplement>(
                 emptySupplement,
                 "supplement",   // Prefix for form value.
                 s => s.Id, s => s.ProductID, s => s.SupplementAdded, s => s.SupplementAvailability, s => s.SupplementType))
            {
                _context.Supplements.Add(emptySupplement);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            // Select ProductID if TryUpdateModelAsync fails.
            PopulateProductsDropDownList(_context, emptySupplement.ProductID);
            return Page();
        }
    }
}
