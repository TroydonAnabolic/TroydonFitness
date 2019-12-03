using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TroydonFitness.Data;
using TroydonFitness.Models.ProductModel;

namespace TroydonFitness.Pages.SupplementRoutines
{
    public class DeleteModel : PageModel
    {
        private readonly TroydonFitness.Data.ProductContext _context;

        public DeleteModel(TroydonFitness.Data.ProductContext context)
        {
            _context = context;
        }

        [BindProperty]
        public SupplementRoutine SupplementRoutine { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            SupplementRoutine = await _context.SupplementRoutine
                .Include(s => s.CustomizedRoutine)
                .Include(s => s.Supplement).FirstOrDefaultAsync(m => m.SupplementId == id);

            if (SupplementRoutine == null)
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

            SupplementRoutine = await _context.SupplementRoutine.FindAsync(id);

            if (SupplementRoutine != null)
            {
                _context.SupplementRoutine.Remove(SupplementRoutine);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
