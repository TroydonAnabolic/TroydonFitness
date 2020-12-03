using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TroydonFitnessWebsite.Areas.Identity.Data;
using TroydonFitnessWebsite.Areas.Identity.Data.Authorization;
using TroydonFitnessWebsite.Data;
using TroydonFitnessWebsite.Models.Products;
using TroydonFitnessWebsite.Pages.CustomisedModel;

namespace TroydonFitnessWebsite.Pages.Products
{
    public class DetailsModel : PageModel
    {
        private readonly ProductContext _context;

        public DetailsModel(
            ProductContext context)

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

            Product = await _context.Products
               // we are getting the props of pt session, this will be available in a box that says show details, which will reveal a hidden box showing this
               .Include(p => p.PersonalTrainingSessions)
                   .ThenInclude(train => train.TrainingRoutine)
               .AsNoTracking()
               .FirstOrDefaultAsync(m => m.ProductID == id);

            // Product = await _context.Products.FirstOrDefaultAsync(m => m.ProductID == id);

            if (Product == null)
            {
                return NotFound();
            }

            // returns user to sign in page if not authenticated
            if (!User.Identity.IsAuthenticated)
            {
                return Challenge();
            }

            return Page();
        }
    }
}
