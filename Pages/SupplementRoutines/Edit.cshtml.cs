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

namespace TroydonFitness.Pages.SupplementRoutines
{
    public class EditModel : PageModel
    {
        private readonly TroydonFitness.Data.ProductContext _context;

        public EditModel(TroydonFitness.Data.ProductContext context)
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
           ViewData["CustomizedRoutineId"] = new SelectList(_context.CustomizedRoutines, "Id", "ExerciseDetails");
           ViewData["SupplementId"] = new SelectList(_context.Supplements, "Id", "Id");
            return Page();
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(SupplementRoutine).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SupplementRoutineExists(SupplementRoutine.SupplementId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool SupplementRoutineExists(int id)
        {
            return _context.SupplementRoutine.Any(e => e.SupplementId == id);
        }
    }
}
