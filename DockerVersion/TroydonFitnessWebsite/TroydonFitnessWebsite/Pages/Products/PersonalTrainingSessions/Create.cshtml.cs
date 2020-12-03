using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TroydonFitnessWebsite.Areas.Identity.Data;
using TroydonFitnessWebsite.Models.Products;
using TroydonFitnessWebsite.Pages.CustomisedModel;

namespace TroydonFitnessWebsite.Pages.Products.PersonalTrainingSessions
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
        // making this as the select item list allows me to set the value of my display name to be the selected from the list item
        // list of product titles loaded from DB to be used 
        [BindProperty]
        public IEnumerable<Product> displayProductTitles { get; set; }
        // this value will be set on the select list item and is equal to the producttitle ID of the product title we are looking for
        [BindProperty]
        public int getIndexOfTitleList { get; set; }
        [BindProperty]
        public PersonalTrainingVM PersonalTrainingVM { get; set; }


        public async Task<IActionResult> OnGet()
        {

            PopulateProductDropDownList(_context);

            displayProductTitles = await _context.Products.ToListAsync();
            return Page();
        }



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

            var emptyPtSession = new PersonalTraining();

            // display the available select list items
            displayProductTitles = await _context.Products.ToListAsync();

            var entry = _context.Add(emptyPtSession);

            // this is the line that can manually set values of the pt name, searches the products, when the prod id == the index assigned, we get the first item, thats a title, and convert to string
            PersonalTrainingVM.PersonalTrainingName = displayProductTitles.Where(a => a.ProductID == getIndexOfTitleList).FirstOrDefault().Title.ToString();

            // add product picture
            if (Request.Form.Files.Count > 0)
            {
                IFormFile file = Request.Form.Files.FirstOrDefault();
                using (var dataStream = new MemoryStream())
                {
                    await file.CopyToAsync(dataStream);
                    PersonalTrainingVM.PtProductPicture = dataStream.ToArray();
                }
            }

            entry.CurrentValues.SetValues(PersonalTrainingVM);
            await _context.SaveChangesAsync();

            PopulateProductDropDownList(_context, emptyPtSession.ProductID);


            return RedirectToPage("./Index");
        }
        // Select DepartmentID if TryUpdateModelAsync fails.

    }
}

