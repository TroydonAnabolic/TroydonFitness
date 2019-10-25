using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TroydonFitness.Data;
using TroydonFitness.Models.ProductModel;

namespace TroydonFitness.Pages.CustomizedRoutines
{
    public class DeleteRoutineModel : PageModel
    {
        private readonly TroydonFitness.Data.ProductContext _context;

        public DeleteRoutineModel(TroydonFitness.Data.ProductContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CustomizedRoutine CustomizedRoutine { get; set; }
        public string ErrorMessage { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            CustomizedRoutine = await _context.CustomizedRoutines
                .AsNoTracking()
                .Include(p => p.Product)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (CustomizedRoutine == null)
            {
                return NotFound();
            }

            if (saveChangesError.GetValueOrDefault())
            {
                ErrorMessage = "Delete failed. Try again";
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var routine = await _context.CustomizedRoutines.FindAsync(id);

            if (routine == null)
            {
                return NotFound();
            }

            try
            {
                _context.CustomizedRoutines.Remove(routine);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.)
                return RedirectToAction("./Delete",
                                     new { id, saveChangesError = true });
            }
        }
    }
}
