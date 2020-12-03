using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TroydonFitnessWebsite.Areas.Identity.Data;
using TroydonFitnessWebsite.Data;
using TroydonFitnessWebsite.Models.Products;
using TroydonFitnessWebsite.Models.Products.ViewModels;
using TroydonFitnessWebsite.Pages.CustomisedModel;

namespace TroydonFitnessWebsite.Pages.Products.Supplements
{
    [Authorize(Policy = "ElevatedRights")]
    public class CreateModel : FilterSortModel
    {
        private readonly Data.ProductContext _context;
        private readonly UserManager<TroydonFitnessWebsiteUser> _userManager;

        public CreateModel(
            Data.ProductContext context,
            UserManager<TroydonFitnessWebsiteUser> userManager) : base(userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [BindProperty]
        public IEnumerable<Product> displayProductTitles { get; set; }
        [BindProperty]
        public int getIndexOfTitleList { get; set; }
        [BindProperty]
        public SupplementVM SupplementVM { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            // gets the logged in user
            var user = await _userManager.GetUserAsync(HttpContext.User);

            if (user == null)
            {
                return RedirectToPage("/Account/Manage/Login");
            }


            if (user.IsMasterAdmin)
            {
                PopulateProductDropDownList(_context);

                displayProductTitles = await _context.Products.ToListAsync();
                return Page();
            }
            else return RedirectToPage("/Index");
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = await _userManager.GetUserAsync(HttpContext.User);

            if (user == null)
            {
                return RedirectToPage("/Account/Manage/Login");
            }

            var emptySupplement = new Supplement();

            // display the available select list items
            displayProductTitles = await _context.Products.ToListAsync();

            var entry = _context.Add(emptySupplement);

            // add product picture
            if (Request.Form.Files.Count > 0)
            {
                IFormFile file = Request.Form.Files.FirstOrDefault();
                using (var dataStream = new MemoryStream())
                {
                    await file.CopyToAsync(dataStream);
                    SupplementVM.SupplementPicture = dataStream.ToArray();
                }
            }

            entry.CurrentValues.SetValues(SupplementVM);
            await _context.SaveChangesAsync();

            PopulateProductDropDownList(_context, emptySupplement.ProductID);


            return RedirectToPage("./Index");
        }
    }
}
