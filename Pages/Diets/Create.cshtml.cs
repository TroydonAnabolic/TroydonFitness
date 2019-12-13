using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TroydonFitness.Data;
using TroydonFitness.Models.ProductModel;

namespace TroydonFitness.Pages.Diets
{
    public class CreateModel : DietSupplementPageModel
    {
        private readonly TroydonFitness.Data.ProductContext _context;

        public CreateModel(TroydonFitness.Data.ProductContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            var diet = new Diet();
            diet.SupplementRoutine = new List<SupplementRoutine>();

            // Provides an empty collection for the foreach loop
            // foreach (var course in Model.AssignedCourseDataList)
            // in the Create Razor page.
            PopulateAssignedDietData(_context, diet);
            return Page();
        }

        [BindProperty]
        public Diet Diet { get; set; }

        public enum Type
        {
            looseWeight,
            gainMuscle,
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(string[] selectedSupplements)
        {
            var newDiet = new Diet();
            if (selectedSupplements != null)
            {
                newDiet.SupplementRoutine = new List<SupplementRoutine>();
                foreach (var supplement in selectedSupplements)
                {
                    var supplementToAdd = new SupplementRoutine
                    {
                        SupplementId = int.Parse(supplement)
                    };
                    newDiet.SupplementRoutine.Add(supplementToAdd);
                }
            }

            if (await TryUpdateModelAsync<Diet>(
                newDiet,
                "Diet",
                i => i.DietWeight, i => i.DietType,
                i => i.SupplementRoutine))
            {
                _context.Diets.Add(newDiet);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            PopulateAssignedDietData(_context, newDiet);
            return Page();
        }
    }
}
