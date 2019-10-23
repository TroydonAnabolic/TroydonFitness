using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TroydonFitness.Data;
using TroydonFitness.Models.ProductModel;

namespace TroydonFitness.Pages.Products
{
    public class DetailsModel : PageModel
    {
        private readonly TroydonFitness.Data.ProductContext _context;

        public DetailsModel(TroydonFitness.Data.ProductContext context)
        {
            _context = context;
        }

        public Product Product { get; set; }


        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //Product = await _context.Products
            //    .Include(p => p.PersonalTrainingSessions).FirstOrDefaultAsync(m => m.ProductID == id);

            Product = await _context.Products
                .Include(pt => pt.PersonalTrainingSessions)
                .Include(c => c.CustomizedRoutines)
                .ThenInclude(t => t.SupplementRoutines) // May need to remove
                .Include(d => d.Diets)
                .Include(s => s.Supplements)
                .Include(t => t.TrainingEquipments)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ProductID == id);


            if (Product == null)
            {
                return NotFound();
            }
            return Page();

        }
    }
}
