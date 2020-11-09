using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TroydonFitnessWebsite.Areas.Identity.Data;
using TroydonFitnessWebsite.Data;
using TroydonFitnessWebsite.Models.Products;
using TroydonFitnessWebsite.Models.Products.ViewModels;
using TroydonFitnessWebsite.Pages.CustomisedModel;

namespace TroydonFitnessWebsite.Pages.Products.Diets
{
    public class CreateModel : FilterSortModel
    {
        private readonly ProductContext _context;

        public CreateModel(ProductContext context,
            UserManager<TroydonFitnessWebsiteUser> userManager) : base(userManager)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            PopulateProductDropDownList(_context);
            return Page();
        }

        [BindProperty]
        public DietVM DietVM { get; set; }
        [BindProperty]
        public List<string> AllergiesList { get; set; } = new List<string>() { "Milk", "Eggs", "Peanuts", "Tree nuts", "Soy", "Wheat", "Fish", "Shellfish", "Corn", "Gelatin", "Meat", "Seeds", "Spices", };

    [BindProperty]
        public string PreferredFood { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var emptyPtSession = new Diet();

            var entry = _context.Add(emptyPtSession);
            OnPostGetAllergyList(AllergiesList);
            entry.CurrentValues.SetValues(DietVM);
            await _context.SaveChangesAsync();

            PopulateProductDropDownList(_context, emptyPtSession.DietID);

            return RedirectToPage("./Index");
        }
        void OnPostGetAllergyList(List<string> allergylist)
        {
            string.Join(",", allergylist);
        }
    }
}
