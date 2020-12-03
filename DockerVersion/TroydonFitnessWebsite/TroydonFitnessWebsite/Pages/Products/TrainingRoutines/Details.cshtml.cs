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
    public class DetailsModel : PageModel
    {
        private readonly TroydonFitnessWebsite.Data.ProductContext _context;

        public DetailsModel(TroydonFitnessWebsite.Data.ProductContext context)
        {
            _context = context;
        }
        // Things to display using values from drop down list: title, price, quantity, available, last updated, length of routine, Description, Session type, experience level

        public TrainingRoutine TrainingRoutine { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TrainingRoutine = await _context.TrainingRoutines
                .Include(t => t.PersonalTrainingSession).
                FirstOrDefaultAsync(m => m.TrainingRoutineID == id);

            if (TrainingRoutine == null)
            {
                return NotFound();
            }
            return Page();
        }



    }
}
