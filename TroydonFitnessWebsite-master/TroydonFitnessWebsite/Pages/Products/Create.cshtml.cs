using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TroydonFitnessWebsite.Areas.Identity.Data;
using TroydonFitnessWebsite.Areas.Identity.Data.Authorization;
using TroydonFitnessWebsite.Data;
using TroydonFitnessWebsite.Models.Products;
using TroydonFitnessWebsite.Pages.CustomisedModel;

namespace TroydonFitnessWebsite.Pages.Products
{
    public class CreateModel : FilterSortModel
    {
        private readonly ProductContext _context;

        // TODO: Add Select List option like training routine VM so we can add any type of product to the list, customer views product details page not training routine

        public CreateModel(
            ProductContext context,
            UserManager<TroydonFitnessWebsiteUser> userManager) : base(userManager)

        //: base(context, authorizationService, userManager TO DO: may need to go base context, and usermanager
            
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        // [BindProperty]
        // public Product Product { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD., below code is vunerable to overposting
        //public async Task<IActionResult> OnPostAsync()
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return Page();
        //    }

        //    _context.Products.Add(Product);
        //    await _context.SaveChangesAsync();

        //    return RedirectToPage("./Index");
        //}

        // Method to prevent overposting using lambda manually
        //public async Task<IActionResult> OnPostAsync()
        //{
        //    var emptyProduct = new Product();

        //    if (await TryUpdateModelAsync<Product>(
        //        emptyProduct,
        //        "product",   // Prefix for form value.
        //        p => p.Title, p => p.ShortDescription, p => p.Price, p => p.Quantity, p => p.Quantity, p => p.HasStock, p => p.LastUpdated))
        //    {
        //        _context.Products.Add(emptyProduct);
        //        await _context.SaveChangesAsync();
        //        return RedirectToPage("./Index");
        //    }
        //        return Page();
        //}

        // Using View models to prevent overposting
        [BindProperty]
        public ProductVM ProductVM { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var entry = _context.Add(new Product());
            entry.CurrentValues.SetValues(ProductVM);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}
