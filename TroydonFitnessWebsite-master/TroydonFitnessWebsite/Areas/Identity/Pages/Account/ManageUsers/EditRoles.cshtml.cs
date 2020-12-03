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
using TroydonFitnessWebsite.Services;

namespace TroydonFitnessWebsite.Areas.Identity.Pages.Account.ManageUsers
{
    public class EditRolesModel : PageModel
    {
        public class EditModel : DI_BaseIdentityPageModel
        {
            private readonly TroydonFitnessIdentityContext _context;
            private readonly ManageRoleService _manageRoleService;

            public EditModel(
                TroydonFitnessIdentityContext context,
                IAuthorizationService authorizationService,
                ManageRoleService manageRoleService,
                UserManager<TroydonFitnessWebsiteUser> userManager)
                : base(context, authorizationService, userManager)

            {
                _context = context;
                _manageRoleService = manageRoleService;
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

                    return Page();
            }

            // TODO: Try to implement master admin to manually adjust the roles
            public async Task<IActionResult> OnPostAsync()
            {

              //  await _manageRoleService.CreateUserRoles(serviceProvider);

                return RedirectToPage("/ListUsers");

            }
        }
    }
}
