using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TroydonFitness.Data;
using TroydonFitness.Models.ProductModel;

namespace TroydonFitness.Pages.Supplements
{
    public class DeleteModel : PageModel
    {
        private readonly TroydonFitness.Data.ProductContext _context;

        public DeleteModel(TroydonFitness.Data.ProductContext context)
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
                .AsNoTracking()
                .Include(p => p.Product)
                .FirstOrDefaultAsync(m => m.Id == id);

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
