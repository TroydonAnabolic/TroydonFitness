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

namespace TroydonFitness.Pages.Products
{
    public class EditModel : PageModel
    {
        private readonly TroydonFitness.Data.ProductContext _context;

        public EditModel(TroydonFitness.Data.ProductContext context)
        {
            _context = context;
        }
        public enum Availability
        {
            Available,
            Unavailable,
            ComingSoon
        }

        [BindProperty]
        public Product Product { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Product = await _context.Products
                .Include(p => p.PersonalTrainingSessions).FirstOrDefaultAsync(m => m.ProductID == id);

            if (Product == null)
            {
                return NotFound();
            }
           ViewData["PersonalTrainingId"] = new SelectList(_context.Set<PersonalTraining>(), "PersonalTrainingID", "PersonalTrainingID");
            return Page();
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int id)
        {
            var studentToUpdate = await _context.Products.FindAsync(id);

            if (studentToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Product>(
                studentToUpdate,
                "product",
                p => p.Title, p => p.Description, p => p.Price,
                p => p.Quantity, p => p.HasStock, p => p.ProductAdded))
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
