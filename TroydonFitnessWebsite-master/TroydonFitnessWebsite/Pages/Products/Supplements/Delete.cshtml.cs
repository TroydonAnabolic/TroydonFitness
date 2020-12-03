using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TroydonFitnessWebsite.Data;
using TroydonFitnessWebsite.Models.Products;

namespace TroydonFitnessWebsite.Pages.Products.Supplements
{
    public class DeleteModel : PageModel
    {
        private readonly TroydonFitnessWebsite.Data.ProductContext _context;

        public DeleteModel(TroydonFitnessWebsite.Data.ProductContext context)
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
                .Include(s => s.Diet)
                .Include(s => s.Product).FirstOrDefaultAsync(m => m.SupplementID == id);

            if (Supplement == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Supplement = await _context.Supplements.FindAsync(id);

            if (Supplement != null)
            {
                _context.Supplements.Remove(Supplement);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
