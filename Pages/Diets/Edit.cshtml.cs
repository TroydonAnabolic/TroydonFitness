using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TroydonFitness.Data;
using TroydonFitness.Models.ProductModel;

namespace TroydonFitness.Pages.Diets
{
    public class EditModel : DietSupplementPageModel
    {
        private readonly ProductContext _context;

        public EditModel(ProductContext context)
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

            Diet = await _context.Diets.FirstOrDefaultAsync(m => m.Id == id);

            Diet = await _context.Diets
               .Include(i => i.TrainingEquipment)
               .Include(i => i.SupplementRoutine).ThenInclude(i => i.Supplement)
               .AsNoTracking()
               .FirstOrDefaultAsync(m => m.Id == id);


            if (Diet == null)
            {
                return NotFound();
            }
            PopulateAssignedDietData(_context, Diet);

            return Page();
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedSupplements)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dietToUpdate = await _context.Diets
                .Include(i => i.TrainingEquipment)
                .Include(i => i.SupplementRoutine)
                    .ThenInclude(i => i.Supplement)
                .FirstOrDefaultAsync(s => s.Id == id);

            if (dietToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Diet>(
                dietToUpdate,
                "Diets",
                i => i.DietType, i => i.DietWeight,
                i => i.TrainingEquipment))
            {
                if (String.IsNullOrWhiteSpace(
                    dietToUpdate.TrainingEquipment?.Brand))
                {
                    dietToUpdate.TrainingEquipment = null;
                }
                UpdateInstructorCourses(_context, selectedSupplements, dietToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            UpdateInstructorCourses(_context, selectedSupplements, dietToUpdate);
            PopulateAssignedDietData(_context, dietToUpdate);
            return Page();
        }
    }
}
