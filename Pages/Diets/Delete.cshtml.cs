using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TroydonFitness.Data;
using TroydonFitness.Models.ProductModel;

namespace TroydonFitness.Pages.Diets
{
    public class DeleteModel : PageModel
    {
        private readonly TroydonFitness.Data.ProductContext _context;

        public DeleteModel(TroydonFitness.Data.ProductContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Diet Diet { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Diet = await _context.Diets.FirstOrDefaultAsync(m => m.Id == id);

            if (Diet == null)
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

            Diet diet = await _context.Diets
                .Include(i => i.SupplementRoutine)
                .SingleAsync(i => i.Id == id);

            if (diet == null)
            {
                return RedirectToPage("./Index");
            }

            var departments = await _context.Products
                .Where(d => d.DietID == id)
                .ToListAsync();
            departments.ForEach(d => d.DietID = null);

            _context.Diets.Remove(diet);

            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
