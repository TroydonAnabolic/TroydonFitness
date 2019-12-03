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
    public class DetailsModel : PageModel
    {
        private readonly TroydonFitness.Data.ProductContext _context;

        public DetailsModel(TroydonFitness.Data.ProductContext context)
        {
            _context = context;
        }

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
    }
}
