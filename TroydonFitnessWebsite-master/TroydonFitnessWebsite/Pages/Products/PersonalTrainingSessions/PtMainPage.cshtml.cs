using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TroydonFitnessWebsite.Pages.Products.PersonalTrainingSessions
{
    [AllowAnonymous]
    public class PtMainPageModel : PageModel
    {
        public void OnGet()
        {

        }
    }
}