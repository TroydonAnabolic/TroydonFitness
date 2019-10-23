using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TroydonFitness.Data;
using TroydonFitness.Models.ProductModel;

namespace TroydonFitness.Pages.CustomizedRoutines
{
    public class CreateRoutineModel : PageModel
    {
        private readonly TroydonFitness.Data.ProductContext _context;

        public CreateRoutineModel(TroydonFitness.Data.ProductContext context)
        {
            _context = context;
        }

        public enum Difficulty
        {
            Beginner,
            Intermediate,
            Advanced
        }

        public IActionResult OnGet()
        {
        ViewData["ProductID"] = new SelectList(_context.Set<Product>(), "ProductID", "ProductID");
            return Page();
        }

        [BindProperty]
        public CustomizedRoutine CustomizedRoutine { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.CustomizedRoutines.Add(CustomizedRoutine);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
