using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TroydonFitnessWebsite.Data;
using TroydonFitnessWebsite.Models.Products;

namespace TroydonFitnessWebsite.Pages.Products.Orders.ManageCart
{
    public class IndexModel : PageModel
    {
        private readonly TroydonFitnessWebsite.Data.ProductContext _context;

        public IndexModel(TroydonFitnessWebsite.Data.ProductContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["DietID"] = new SelectList(_context.Diets, "DietID", "DietID");
        ViewData["SupplementID"] = new SelectList(_context.Supplements, "SupplementID", "SupplementID");
        ViewData["TrainingEquipmentID"] = new SelectList(_context.TrainingEquipmentPurchases, "TrainingEquipmentID", "TrainingEquipmentID");
        ViewData["TrainingRoutineID"] = new SelectList(_context.TrainingRoutines, "TrainingRoutineID", "TrainingRoutineID");
            return Page();
        }

        [BindProperty]
        public Cart Cart { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.CartItems.Add(Cart);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
