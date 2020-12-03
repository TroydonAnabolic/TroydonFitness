using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TroydonFitnessWebsite.Data;
using TroydonFitnessWebsite.Models.Products;

namespace TroydonFitnessWebsite.Pages.Products.Diets
{
    public class DetailsModel : PageModel
    {
        private readonly TroydonFitnessWebsite.Data.ProductContext _context;

        public DetailsModel(TroydonFitnessWebsite.Data.ProductContext context)
        {
            _context = context;
        }

        public Diet Diet { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Diet = await _context.Diets
                .Include(d => d.PersonalTrainingSession).FirstOrDefaultAsync(m => m.DietID == id);

            if (Diet == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
