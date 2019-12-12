using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TroydonFitness.Data;
using TroydonFitness.Models.ProductModel;

namespace TroydonFitness.Pages.Supplements
{
    public class EditModel : ProductNamePageModel
    {
        private readonly ProductContext _context;

        public EditModel(ProductContext context)
        {
            _context = context;
        }

        [BindProperty]  
        public Supplement Supplement { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Supplement = await _context.Supplements
                .Include(c => c.Product).FirstOrDefaultAsync(m => m.ProductID == id);


            if (Supplement == null)
            {
                return NotFound();
            }

            // Select current ProductID.
            PopulateProductsDropDownList(_context, Supplement.ProductID);
            return Page();
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supplementToUpdate = await _context.Supplements.FindAsync(id);

            if (supplementToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Supplement>(
                 supplementToUpdate,
                 "supplement",   // Prefix for form value.
                   c => c.Product.Price, c => c.ProductID, c => c.Product.Title))
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            // Select DepartmentID if TryUpdateModelAsync fails.
            PopulateProductsDropDownList(_context, supplementToUpdate.ProductID);
            return Page();
        }

        private bool SupplementExists(int id)
        {
            return _context.Supplements.Any(e => e.Id == id);
        }
    }
}
