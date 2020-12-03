using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TroydonFitnessWebsite.Models.Products;

namespace TroydonFitnessWebsite.Pages.Products.Orders.ManageCart
{
    public class CartItemDetailsModel : PageModel
    {
        private readonly Data.ProductContext _context;

        public CartItemDetailsModel(Data.ProductContext context)
        {
            _context = context;
        }

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
                .Include(c => c.TrainingRoutine)
                    .ThenInclude(c => c.PersonalTrainingSession)
                        .ThenInclude(c => c.Product)
                .FirstOrDefaultAsync(m => m.CartID == id);

            if (Cart == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
