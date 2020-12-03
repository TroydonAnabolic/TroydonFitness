using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TroydonFitnessWebsite.Areas.Identity.Data;
using TroydonFitnessWebsite.Data;

namespace TroydonFitnessWebsite.Areas.Identity.Pages.Account.ManageUsers
{
    public class EditModel : DI_BaseIdentityPageModel
    {
        private readonly TroydonFitnessIdentityContext _context;

        public EditModel(
            TroydonFitnessIdentityContext context,
            IAuthorizationService authorizationService,
            UserManager<TroydonFitnessWebsiteUser> userManager)
            : base(context, authorizationService, userManager)

        {
            _context = context;
        }

        [BindProperty]
        public TroydonFitnessWebsiteUser TroydonFitnessWebsiteUser { get; set; }

        public async Task<IActionResult> OnGetAsync(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TroydonFitnessWebsiteUser = await _context.Users.FindAsync(id);

            if (TroydonFitnessWebsiteUser == null)
            {
                return NotFound();
            }

            //// authorized users only can view
            //var isAuthorized = await AuthorizationService.AuthorizeAsync(
            //                                   User, Product,
            //                                   ProductOperations.Update);
            //if (!isAuthorized.Succeeded)
            //{
            //    return Forbid();
            //}

            return Page();
        }


        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(string id)
        {
            // When you don't have to include related data, FindAsync is more efficient.
            var userToUpdate = await _context.Users.FindAsync(id);

            if (userToUpdate == null)
            {
                return NotFound();
            }

            // determine to proceed based on whether authorised
            //var isAuthorized = await AuthorizationService.AuthorizeAsync(
            //                                  User, Product,
            //                                  ProductOperations.Update);
            //if (!isAuthorized.Succeeded)
            //{
            //    return Forbid();
            //}


            if (await TryUpdateModelAsync<TroydonFitnessWebsiteUser>(
                userToUpdate,
                "User",
                p => p.UserName, p => p.FirstName, p => p.LastName, p => p.Email, p => p.EmailConfirmed, p => p.PhoneNumber, p => p.IsAdmin, p => p.IsMasterAdmin,
                 p => p.ActivityType, p => p.AddressLine1, p => p.AddressLine2, p => p.City, p => p.State, p => p.Zip,
                  p => p.Bodyfat, p => p.Gender, p => p.Height, p => p.Weight
                ))
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("./ListUsers");
            }

            return Page();
        }

        private bool ProductExists(string id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}