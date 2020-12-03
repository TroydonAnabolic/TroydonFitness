using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TroydonFitnessWebsite.Areas.Identity.Data.CustomIdentityConfig.IdentityModel;

namespace TroydonFitnessWebsite.Pages.Account
{
    public class AuthenticateTestModel : PageModel
    {

        public async Task OnGetAsync()
        {
            ClaimsPrincipal userPrincipal = CreateTestUserPrincipal();

            await HttpContext.SignInAsync(userPrincipal);

            RedirectToPage("/Index");
        }

        public async Task<IActionResult> OnPostAsync()
        {
            ClaimsPrincipal userPrincipal = CreateTestUserPrincipal();

            await HttpContext.SignInAsync(userPrincipal);

            RedirectToPage("/Index");

            return Page();
        }

        private static ClaimsPrincipal CreateTestUserPrincipal()
        {
            var grandmaClaims = new List<Claim>()
            {

                new Claim(JwtClaimTypes.Name, "Bob"),
                new Claim(JwtClaimTypes.Email, "Bob@fmail.com"),
                new Claim(JwtClaimTypes.Role, "MasterAdmin"),
                new Claim("Grandma.Says", "Very nice boi."),
            };

            var licenseClaims = new List<Claim>()
            {
                new Claim(JwtClaimTypes.Name, "Bob K Foo"),
                new Claim("DrivingLicense", "A+")
            };

            var grandmaIdentity = new ClaimsIdentity(grandmaClaims, "Grandma Identity");
            var licenseIdentity = new ClaimsIdentity(licenseClaims, "Government");

            var userPrincipal = new ClaimsPrincipal(new[] { grandmaIdentity, licenseIdentity });
            return userPrincipal;
        }
    }
}