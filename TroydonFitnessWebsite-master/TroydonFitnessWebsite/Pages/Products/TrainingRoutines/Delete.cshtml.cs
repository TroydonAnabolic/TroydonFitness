using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TroydonFitnessWebsite.Data;
using TroydonFitnessWebsite.Models.Products;

namespace TroydonFitnessWebsite.Pages.Products.TrainingRoutines
{
    public class DeleteModel : PageModel
    {
        private readonly TroydonFitnessWebsite.Data.ProductContext _context;

        public DeleteModel(TroydonFitnessWebsite.Data.ProductContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TrainingRoutine TrainingRoutine { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TrainingRoutine = await _context.TrainingRoutines
                .Include(t => t.PersonalTrainingSession).FirstOrDefaultAsync(m => m.TrainingRoutineID == id);

            if (TrainingRoutine == null)
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

            TrainingRoutine = await _context.TrainingRoutines.FindAsync(id);

            if (TrainingRoutine != null)
            {
                _context.TrainingRoutines.Remove(TrainingRoutine);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
