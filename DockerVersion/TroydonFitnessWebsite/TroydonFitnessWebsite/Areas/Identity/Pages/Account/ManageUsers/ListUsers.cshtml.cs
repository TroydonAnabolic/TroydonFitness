using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TroydonFitnessWebsite.Areas.Identity.Data;
using TroydonFitnessWebsite.Data;

namespace TroydonFitnessWebsite.Areas.Identity.Pages.Account.ManageUsers
{
    // this class allows master admins to assign administrative priviliges to other users
    public class ListUsersModel : DI_BaseIdentityPageModel
    {
        private readonly TroydonFitnessIdentityContext _context;

        public ListUsersModel(
            TroydonFitnessIdentityContext context,
            IAuthorizationService authorizationService,
            UserManager<TroydonFitnessWebsiteUser> userManager)
            : base(context, authorizationService, userManager)

        {
            _context = context;
        }

        public IList<TroydonFitnessWebsiteUser> TroydonFitnessWebsiteUsers { get; set; }

        public async Task OnGetAsync()
        {
            TroydonFitnessWebsiteUsers = await _context.Users.ToListAsync();
        }

    }
}
