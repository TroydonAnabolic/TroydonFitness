using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TroydonFitness.Data;
using TroydonFitness.Models.ProductModel;

namespace TroydonFitness.Pages.Supplements
{
    public class DetailsModel : PageModel
    {
        private readonly TroydonFitness.Data.ProductContext _context;

        public DetailsModel(TroydonFitness.Data.ProductContext context)
        {
            _context = context;
        }

        public Supplement Supplement { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Supplement = await _context.Supplements.FirstOrDefaultAsync(m => m.Id == id);

            if (Supplement == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
