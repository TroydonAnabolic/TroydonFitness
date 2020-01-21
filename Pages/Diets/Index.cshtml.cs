using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TroydonFitness.Data;
using TroydonFitness.Models;
using TroydonFitness.Models.ProductModel;

namespace TroydonFitness.Pages.Diets
{
    public class IndexModel : PageModel
    {
        private readonly TroydonFitness.Data.ProductContext _context;

        public IndexModel(TroydonFitness.Data.ProductContext context)
        {
            _context = context;
        }

        public DietIndexData DietData { get; set; }
        public int DietID { get; set; }
        public int SupplementID { get; set; }

        public async Task OnGetAsync(int? id, int? supplementID)
        {
            DietData = new DietIndexData();
            DietData.Diets = await _context.Diets
                .Include(i => i.TrainingEquipment)
                .Include(i => i.SupplementRoutine) // Many to many class contains supp routine
                    .ThenInclude(i => i.Supplement) // supplement nav prop is present in the many to many joint class
                        .ThenInclude(i => i.Product) // Product nav prop is present in Supplement
                //.Include(i => i.SupplementRoutine)
                //    .ThenInclude(i => i.Supplement)
                //        .ThenInclude(i => i.CustomizedRoutines)
                //            .ThenInclude(i => i.Product)
                .Include(i => i.SupplementRoutine)
                    .ThenInclude(i => i.CustomizedRoutine) // CustomizedRoutine present in supp routine
                        .ThenInclude(i => i.Product) // Retreive the nav prop product from routine
                .Include(i => i.SupplementRoutine)
                    .ThenInclude(i => i.CustomizedRoutine) // CustomizedRoutine present in supp routine
                        .ThenInclude(i => i.Product) // Retreive the nav prop product from routine
                .Include(i => i.SupplementRoutine)
                    .ThenInclude(i => i.CustomizedRoutine) // CustomizedRoutine present in supp routine
                        .ThenInclude(i => i.Product) // Retreive the nav prop product from r
                .AsNoTracking()
                .OrderBy(i => i.Id)
                .ToListAsync();

            if (id != null)
            {
                DietID = id.Value;
                Diet diet = DietData.Diets.Single(
                    i => i.Id == id.Value);
                DietData.Supplements = diet.SupplementRoutine.Select(s => s.Supplement);
            }

            if (supplementID != null)
            {
                SupplementID = supplementID.Value;
                var selectedSupplement = DietData.Supplements
                    .Where(x => x.Id == supplementID).Single();
                await _context.Entry(selectedSupplement).Collection(x => x.CustomizedRoutines).LoadAsync();
                foreach (CustomizedRoutine routine in selectedSupplement.CustomizedRoutines)
                {
                    await _context.Entry(routine).Reference(x => x.Product).LoadAsync();
                }
                DietData.CustomizedRoutines = selectedSupplement.CustomizedRoutines;
            }
        }
    }

}