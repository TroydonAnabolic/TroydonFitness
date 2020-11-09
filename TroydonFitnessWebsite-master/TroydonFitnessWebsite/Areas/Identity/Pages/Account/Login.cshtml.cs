using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using TroydonFitnessWebsite.Areas.Identity.Data;
using TroydonFitnessWebsite.Data;

namespace TroydonFitnessWebsite.Pages.Account
{
    public class LoginModel : IndexModel
    {
        public LoginModel(SignInManager<TroydonFitnessWebsiteUser> signInManager,
            ILogger<Microsoft.AspNetCore.Identity.UI.V3.Pages.Account.Internal.LoginModel> logger,
            UserManager<TroydonFitnessWebsiteUser> userManager, ProductContext context) : base(signInManager, logger, userManager, context )
        {
        }

    }
}