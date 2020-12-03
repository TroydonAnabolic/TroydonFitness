using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TroydonFitnessWebsite.Data;
using TroydonFitnessWebsite.Models.Products;

namespace TroydonFitnessWebsite.Pages.Products.TrainingRoutines
{
    public class EditModel : PageModel
    {
        private readonly ProductContext _context;

        public EditModel(ProductContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TrainingRoutine TrainingRoutine { get; set; }
        // Customer can select all options, but its to select their preferred available dates
        [Display(Name = "Preferred Days Available")]
        public List<string> DailyAvailability { get; set; } = new List<string>() { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
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
           ViewData["PersonalTrainingID"] = new SelectList(_context.PersonalTrainingSessions, "PersonalTrainingID", "PersonalTrainingID");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(TrainingRoutine).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrainingRoutineExists(TrainingRoutine.TrainingRoutineID))
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

        private bool TrainingRoutineExists(int id)
        {
            return _context.TrainingRoutines.Any(e => e.TrainingRoutineID == id);
        }
    }
}
