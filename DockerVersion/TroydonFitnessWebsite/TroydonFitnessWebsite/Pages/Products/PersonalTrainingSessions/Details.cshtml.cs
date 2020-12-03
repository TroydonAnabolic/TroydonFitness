using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TroydonFitnessWebsite.Data;
using TroydonFitnessWebsite.Models.Products;

namespace TroydonFitnessWebsite.Pages.Products.PersonalTrainingSessions
{
    public class DetailsModel : PageModel
    {
        private readonly TroydonFitnessWebsite.Data.ProductContext _context;

        public DetailsModel(TroydonFitnessWebsite.Data.ProductContext context)
        {
            _context = context;
        }

        public PersonalTraining PersonalTraining { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PersonalTraining = await _context.PersonalTrainingSessions
                .AsNoTracking()
                .Include(p => p.Product)
                .FirstOrDefaultAsync(m => m.PersonalTrainingID == id);

            if (PersonalTraining == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
