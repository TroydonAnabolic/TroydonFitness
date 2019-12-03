using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TroydonFitness.Data;
using TroydonFitness.Models.ProductModel;

namespace TroydonFitness.Pages.SupplementRoutines
{
    [BindProperties]
    public class CreateModel : PageModel
    {
        private readonly TroydonFitness.Data.ProductContext _context;

        public CreateModel(TroydonFitness.Data.ProductContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["CustomizedRoutineId"] = new SelectList(_context.CustomizedRoutines, "Id", "ExerciseDetails");
        ViewData["SupplementId"] = new SelectList(_context.Supplements, "Id", "Id");
            return Page();
        }

        public SupplementRoutine SupplementRoutine { get; set; }
        public CustomizedRoutine CustomizedRoutine { get; set; }
        public Supplement Supplement { get; set; }


        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.SupplementRoutine.Add(SupplementRoutine);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
