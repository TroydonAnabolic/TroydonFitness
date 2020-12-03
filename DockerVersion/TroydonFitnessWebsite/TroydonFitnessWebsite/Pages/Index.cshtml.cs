using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.UI.V3.Pages.Account.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using TroydonFitnessWebsite.Areas.Identity.Data;
using TroydonFitnessWebsite.Data;
using Microsoft.EntityFrameworkCore;
using TroydonFitnessWebsite.Models.Products;

namespace TroydonFitnessWebsite.Pages
{
    public class IndexModel : PageModel
    {
        private readonly UserManager<TroydonFitnessWebsiteUser> _userManager;
        private readonly SignInManager<TroydonFitnessWebsiteUser> _signInManager;
        private readonly ILogger<LoginModel> _logger;
        private readonly ProductContext _context;

        public IndexModel(SignInManager<TroydonFitnessWebsiteUser> signInManager,
            ILogger<LoginModel> logger,
            UserManager<TroydonFitnessWebsiteUser> userManager,
            ProductContext productContext
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _context = productContext;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }
        public IList<PersonalTraining> PtProductsToDisplay { get; set; }

        public string ReturnUrl { get; set; }

        [TempData]
        public string ErrorMessage { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            public string Email { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            [Display(Name = "Remember me?")]
            public bool RememberMe { get; set; }
        }

        public async Task<IActionResult> OnGetAsync(string returnUrl = null)
        {
            // if the user is authenticated and tries to use the login page via it's URL, send to home page
            //if (Microsoft.AspNetCore.Http.Extensions.UriHelper.GetDisplayUrl(Request).Equals("https://localhost:44311/Identity/Account/Login", System.StringComparison.OrdinalIgnoreCase) && User.Identity.IsAuthenticated)
            //{
            //        Response.Redirect("/Index");
            //}

            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                ModelState.AddModelError(string.Empty, ErrorMessage);
            }

            returnUrl = returnUrl ?? Url.Content("~/");

            // Clear the existing external cookie to ensure a clean login process
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            // query product database to display featured products
            PtProductsToDisplay = await _context.PersonalTrainingSessions
                .Include(p => p.Product)
                .Where(p => p.IsFeatured)
                .ToListAsync();

            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            ReturnUrl = returnUrl;
            ViewData["ShowLoginDetails"] = true;

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");

            if (ModelState.IsValid)
            {
                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, set lockoutOnFailure: true

                var result = await _signInManager.PasswordSignInAsync(Input.Email, Input.Password, Input.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    _logger.LogInformation("User logged in.");
                    return LocalRedirect(returnUrl);
                }
                if (result.RequiresTwoFactor)
                {
                    return RedirectToPage("./LoginWith2fa", new { ReturnUrl = returnUrl, RememberMe = Input.RememberMe });
                }
                if (result.IsLockedOut)
                {
                    _logger.LogWarning("User account locked out.");
                    return RedirectToPage("./Lockout");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return Page();
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
