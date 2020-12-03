using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TroydonFitnessWebsite.Data;
using TroydonFitnessWebsite.Models.Products;

namespace TroydonFitnessWebsite.Pages.Products.Diets
{
    public class EditModel : PageModel
    {
        private readonly TroydonFitnessWebsite.Data.ProductContext _context;

        public EditModel(TroydonFitnessWebsite.Data.ProductContext context)
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

            Diet = await _context.Diets
                .Include(d => d.PersonalTrainingSession).FirstOrDefaultAsync(m => m.DietID == id);

            if (Diet == null)
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

            _context.Attach(Diet).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DietExists(Diet.DietID))
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

        private bool DietExists(int id)
        {
            return _context.Diets.Any(e => e.DietID == id);
        }
    }
}
