﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TroydonFitness.Data;
using TroydonFitness.Models.ProductModel;

namespace TroydonFitness.Pages.Products
{
    public class CreateModel : PageModel
    {
        private readonly TroydonFitness.Data.ProductContext _context;

        public CreateModel(TroydonFitness.Data.ProductContext context)
        {
            _context = context;
        }

        public enum Availability
        {
            Available,
            Unavailable,
            ComingSoon
        }

        public IActionResult OnGet()
        {
        ViewData["PersonalTrainingId"] = new SelectList(_context.Set<PersonalTraining>(), "PersonalTrainingID", "PersonalTrainingID");
            return Page();
        }

        [BindProperty]
        public Product Product { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Products.Add(Product);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}