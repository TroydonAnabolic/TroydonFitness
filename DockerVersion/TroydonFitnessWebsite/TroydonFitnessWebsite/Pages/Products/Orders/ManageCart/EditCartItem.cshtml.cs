using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TroydonFitnessWebsite.Data;
using TroydonFitnessWebsite.Models.Products;

namespace TroydonFitnessWebsite.Pages.Products.Orders.ManageCart
{
    // TODO: Ensure the only thing we can edit in the cart item is the number of items
    [Authorize(Policy = "RequireMasterAdministratorRole")]
    public class EditCartItemModel : PageModel
    {
        private readonly ProductContext _context;

        public EditCartItemModel(ProductContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Cart Cart { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Cart = await _context.CartItems
                .Include(c => c.Diet)
                .Include(c => c.Supplement)
                .Include(c => c.TrainingEquipment)
                .Include(c => c.TrainingRoutine).FirstOrDefaultAsync(m => m.CartID == id);

            if (Cart == null)
            {
                return NotFound();
            }
           ViewData["DietID"] = new SelectList(_context.Diets, "DietID", "DietID");
           ViewData["SupplementID"] = new SelectList(_context.Supplements, "SupplementID", "SupplementID");
           ViewData["TrainingEquipmentID"] = new SelectList(_context.TrainingEquipmentPurchases, "TrainingEquipmentID", "TrainingEquipmentID");
           ViewData["TrainingRoutineID"] = new SelectList(_context.TrainingRoutines, "TrainingRoutineID", "TrainingRoutineID");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Cart).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CartExists(Cart.CartID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CartExists(int id)
        {
            return _context.CartItems.Any(e => e.CartID == id);
        }
    }
}
