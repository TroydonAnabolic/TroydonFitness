using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TroydonFitnessWebsite.Data;
using TroydonFitnessWebsite.Models.Products;

namespace TroydonFitnessWebsite.Pages.Products.Supplements
{
    public class CreateModel : PageModel
    {
        private readonly TroydonFitnessWebsite.Data.ProductContext _context;

        public CreateModel(TroydonFitnessWebsite.Data.ProductContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["DietID"] = new SelectList(_context.Diets, "DietID", "DietID");
        ViewData["ProductID"] = new SelectList(_context.Products, "ProductID", "ProductID");
            return Page();
        }

        [BindProperty]
        public Supplement Supplement { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Supplements.Add(Supplement);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
