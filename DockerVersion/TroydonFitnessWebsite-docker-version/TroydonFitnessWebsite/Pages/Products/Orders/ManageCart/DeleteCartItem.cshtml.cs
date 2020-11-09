using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TroydonFitnessWebsite.Areas.Identity.Data;
using TroydonFitnessWebsite.Data;
using TroydonFitnessWebsite.Models.Products;

namespace TroydonFitnessWebsite.Pages.Products.Orders.ManageCart
{
    public class DeleteCartItemModel : PageModel
    {
        private readonly ProductContext _context;
        private readonly UserManager<TroydonFitnessWebsiteUser> _userManager;


        public DeleteCartItemModel(ProductContext context,
            UserManager<TroydonFitnessWebsiteUser> userManager)
        {
            _context = context;
            _userManager = userManager;
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
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _userManager.GetUserAsync(HttpContext.User);

            if (user == null)
            {
                return RedirectToPage("/Account/Manage/Login");
            }

            Cart = await _context.CartItems.FindAsync(id);

            if (Cart != null)
            {
                // if this is a training routine that we are removing, then reset cool down so we can book a training routine or another diet
                if (Cart.TrainingRoutineID != null || Cart.DietID != null)
                {
                    user.CoolOffDate = DateTime.Now;
                    //user.DietCoolOffDate = DateTime.Now; // TODO: If it is a diet, reset cool down for diet
                }
                _context.CartItems.Remove(Cart);
                await _context.SaveChangesAsync();
                await _userManager.UpdateAsync(user);
            }

            return RedirectToPage("./ViewCart");
        }
    }
}
