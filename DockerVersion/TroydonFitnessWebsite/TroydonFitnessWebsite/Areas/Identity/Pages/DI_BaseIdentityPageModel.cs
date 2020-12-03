using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TroydonFitnessWebsite.Areas.Identity.Data;
using TroydonFitnessWebsite.Data;

namespace TroydonFitnessWebsite.Areas.Identity.Pages
{
    public class DI_BaseIdentityPageModel : PageModel
    {
        protected TroydonFitnessIdentityContext Context { get; }
        protected IAuthorizationService AuthorizationService { get; }
        protected UserManager<TroydonFitnessWebsiteUser> UserManager { get; }

        public DI_BaseIdentityPageModel(
            TroydonFitnessIdentityContext context,
            IAuthorizationService authorizationService,
            UserManager<TroydonFitnessWebsiteUser> userManager) : base()
        {
            Context = context;
            UserManager = userManager;
            AuthorizationService = authorizationService;
        }
    }
}
